using HideluzWebMVC.DAO;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Descrição resumida de BannerController
/// </summary>
namespace HideluzWebMVC.Controllers
{
    public class BannerController
    {
        public string Error { get; set; }
        private BannerModel Banner { get; set; }
        private BannerDAO DataAccessObject { get; set; }

        private const string AlreadyExist = "Já existe um banner com a mesma imagem.";

        private const string InsertSuccess = "Banner cadastrado com sucesso!";
        private const string UpdateSuccess = "Banner atualizado com sucesso!";
        private const string DeleteSuccess = "Banner deletado com sucesso!";

        private const string InsertFail = "Não foi possivel cadastrar o banner, tente novamente!";
        private const string UpdateFail = "Não foi possivel atualizar o banner, tente novamente!";
        private const string DeleteFail = "Não foi possivel deletar o banner, tente novamente!";

        private const string BannerRequiredError = "Os dados do banner devem ser preenchidos.";
        private const string ImageError = "A imagem deve estar em um formato válido.";

        public BannerController()
        {
            Banner = new BannerModel();
            DataAccessObject = new BannerDAO();
        }

        #region create
        private bool NewBanner(string title, string desc, string url)
        {
            Banner.Title = title;
            Banner.Desc = desc;
            Banner.Url = url;

            if (!(DataAccessObject.SearchBanner(Banner) > 0))
            {
                if (DataAccessObject.InsertBanner(Banner) > 0)
                {
                    return true;
                }
                else
                {
                    Error = "O Banner não foi cadastrado.";
                    return false;
                }
            }
            else
            {
                Error = "Já existe um banner com o mesmo nome de arquivo";
                return false;
            }

        }

        public ResponseModel NewBanner(HttpRequest request, Page page)
        {
            var data = request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            if (string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            HttpPostedFile file = request.Files["BannerImg"];

            if (file != null && file.ContentLength > 0 && file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png"))
            {
                string fname = file.FileName;
                if (DataAccessObject.SearchBanner(new BannerModel { Url = fname }) > 0)
                {
                    return new ResponseModel(AlreadyExist, false);
                }
                else
                {
                    if (NewBanner(BannerTitle, BannerDesc, fname))
                    {
                        try
                        {
                            file.SaveAs(page.Server.MapPath(Path.Combine("~/Content/Images/", fname)));
                            return new ResponseModel(InsertSuccess, true);
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(ex.Message, false);
                        }
                    }
                    else
                    {
                        return new ResponseModel(InsertFail, false);
                    }
                }
            }
            else
            {
                return new ResponseModel(ImageError, false);
            }
        }

        private bool NewPlanBanner(string title, string desc, string url)
        {
            Banner.Title = title;
            Banner.Desc = desc;
            Banner.Url = url;

            if (!(DataAccessObject.SearchPlanBanner(Banner) > 0))
            {
                if (DataAccessObject.InsertPlanBanner(Banner) > 0)
                {
                    return true;
                }
                else
                {
                    Error = "O Banner não foi cadastrado.";
                    return false;
                }
            }
            else
            {
                Error = "Já existe um banner com o mesmo nome de arquivo";
                return false;
            }

        }

        public ResponseModel NewPlanBanner(HttpRequest request, Page page)
        {
            var data = request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            if (string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            HttpPostedFile file = request.Files["BannerImg"];
            if (file != null && file.ContentLength > 0 && file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png"))
            {
                string fname = file.FileName;
                if (DataAccessObject.SearchPlanBanner(new BannerModel { Url = fname }) > 0)
                {
                    return new ResponseModel(AlreadyExist, false);
                }
                else
                {
                    if (NewPlanBanner(BannerTitle, BannerDesc, fname))
                    {
                        try
                        {
                            file.SaveAs(page.Server.MapPath(Path.Combine("~/Content/Images/Planos/", fname)));
                            return new ResponseModel(InsertSuccess, true);
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(ex.Message, false);
                        }
                    }
                    else
                    {
                        return new ResponseModel(InsertFail, false);
                    }
                }
            }
            else
            {
                return new ResponseModel(ImageError, false);
            }
        }
        #endregion

        #region read
        public List<BannerModel> SelectAllBanners()
        {
            List<object> banners = DataAccessObject.ReturnAllBanners();
            List<BannerModel> BannerList = new List<BannerModel>();
            int bannerCount = banners.Count;
            for (int i = 0; i < bannerCount; i++)
            {
                var data = (List<String>)banners.ElementAt(i);
                BannerModel bannerModel = new BannerModel
                {
                    Id = data.ElementAt(0),
                    Title = data.ElementAt(1),
                    Desc = data.ElementAt(2),
                    Url = data.ElementAt(3)
                };
                BannerList.Add(bannerModel);
            }
            return BannerList;
        }
        public List<BannerModel> SelectAllPlanBanners()
        {
            List<object> banners = DataAccessObject.ReturnAllPlanBanners();
            List<BannerModel> BannerList = new List<BannerModel>();
            int bannerCount = banners.Count;
            for (int i = 0; i < bannerCount; i++)
            {
                var data = (List<String>)banners.ElementAt(i);
                BannerModel bannerModel = new BannerModel
                {
                    Id = data.ElementAt(0),
                    Title = data.ElementAt(1),
                    Desc = data.ElementAt(2),
                    Url = data.ElementAt(3)
                };
                BannerList.Add(bannerModel);
            }
            return BannerList;
        }
        #endregion

        #region update
        private bool UpdatePlanBanner(string title, string desc, string url, string id)
        {
            BannerModel bannerModel = new BannerModel
            {
                Id = id,
                Title = title,
                Desc = desc,
                Url = url
            };
            return (DataAccessObject.UpdatePlanBanner(bannerModel) > 0);
        }

        public ResponseModel UpdatePlanBanner(HttpRequest request, Page page)
        {
            var data = request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            string BannerUrl = data["BannerUrl"];

            if (string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc) || string.IsNullOrEmpty(BannerUrl))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            HttpPostedFile file = request.Files["BannerImg"];
            if (file != null && file.ContentLength > 0 && file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png"))
            {
                string fname = file.FileName;

                if (BannerUrl != fname && DataAccessObject.SearchPlanBanner(new BannerModel { Url = fname }) > 0)
                {
                    return new ResponseModel(AlreadyExist, false);
                }
                else
                {
                    if (UpdatePlanBanner(BannerTitle, BannerDesc, fname, BannerUrl))
                    {
                        try
                        {
                            //apaga o banner antigo.
                            var path = page.Server.MapPath("~/Content/Images/Planos/" + BannerUrl);
                            File.Delete(path);
                            //salva o novo banner.
                            file.SaveAs(page.Server.MapPath(Path.Combine("~/Content/Images/Planos/", fname)));
                            return new ResponseModel(UpdateSuccess, true);
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(ex.Message, false);
                        }
                    }
                    else
                    {
                        return new ResponseModel(UpdateFail, false);
                    }
                }
            }
            else
            {
                return new ResponseModel(ImageError, false);
            }
        }

        private bool UpdateBanner(string title, string desc, string url, string id)
        {
            BannerModel bannerModel = new BannerModel
            {
                Id = id,
                Title = title,
                Desc = desc,
                Url = url
            };
            return (DataAccessObject.UpdateBanner(bannerModel) > 0);
        }

        public ResponseModel UpdateBanner(HttpRequest request, Page page)
        {
            var data = request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            string BannerUrl = data["BannerUrl"];

            if (string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc) || string.IsNullOrEmpty(BannerUrl))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            HttpPostedFile file = request.Files["BannerImg"];
            if (file != null && file.ContentLength > 0 && file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png"))
            {
                string fname = file.FileName;

                if (BannerUrl != fname && DataAccessObject.SearchBanner(new BannerModel { Url = fname }) > 0)
                {
                    return new ResponseModel(AlreadyExist, false);
                }
                else
                {
                    if (UpdateBanner(BannerTitle, BannerDesc, fname, BannerUrl))
                    {
                        try
                        {
                            //apaga o banner antigo.
                            var path = page.Server.MapPath("~/Content/Images/" + BannerUrl);
                            File.Delete(path);
                            //salva o novo banner.
                            file.SaveAs(page.Server.MapPath(Path.Combine("~/Content/Images/", fname)));
                            return new ResponseModel(UpdateSuccess, true);
                        }
                        catch (Exception ex)
                        {
                            return new ResponseModel(ex.Message, false);
                        }
                    }
                    else
                    {
                        return new ResponseModel(UpdateFail, false);
                    }
                }
            }
            else
            {
                return new ResponseModel(ImageError, false);
            }
        }
        #endregion

        #region delete
        private bool DeleteBanner(string bannerUrl)
        {
            BannerModel bannerModel = new BannerModel
            {
                Url = bannerUrl
            };
            return (DataAccessObject.DeleteBanner(bannerModel) > 0);
        }

        public ResponseModel DeleteBanner(HttpRequest request, Page page)
        {

            var data = request.Form;
            string BannerUrl = data["BannerUrl"];

            if (string.IsNullOrEmpty(BannerUrl))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            if (DeleteBanner(BannerUrl))
            {
                try
                {
                    var path = page.Server.MapPath("~/Content/Images/" + BannerUrl);
                    File.Delete(path);
                    return new ResponseModel(DeleteSuccess, true);
                }
                catch (Exception ex)
                {
                    return new ResponseModel(ex.Message, false);
                }
            }
            else
            {
                return new ResponseModel(DeleteFail, false);
            }
        }

        private bool DeletePlanBanner(string bannerUrl)
        {
            BannerModel bannerModel = new BannerModel
            {
                Url = bannerUrl
            };
            return (DataAccessObject.DeletePlanBanner(bannerModel) > 0);
        }

        public ResponseModel DeletePlanBanner(HttpRequest request, Page page)
        {

            var data = request.Form;
            string BannerUrl = data["BannerUrl"];

            if (string.IsNullOrEmpty(BannerUrl))
            {
                return new ResponseModel(BannerRequiredError, false);
            }
            if (DeletePlanBanner(BannerUrl))
            {
                try
                {
                    var path = page.Server.MapPath("~/Content/Images/Planos/" + BannerUrl);
                    File.Delete(path);
                    return new ResponseModel(DeleteSuccess, true);
                }
                catch (Exception ex)
                {
                    return new ResponseModel(ex.Message, false);
                }
            }
            else
            {
                return new ResponseModel(DeleteFail, false);
            }
        }
        #endregion


    }
}