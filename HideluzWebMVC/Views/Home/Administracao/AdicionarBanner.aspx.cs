using HideluzWebMVC.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Cadastro : System.Web.UI.Page
{
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";
    private string Cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidarSessao();

        if(Page.Request.HttpMethod.Equals("POST")) {

            //instantiate index controoler
            BannerController Controller = new BannerController();

            var data = Request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            if(string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc))
            {
                Response.Write("<script> alert('Todos os campos são obrigatórios!') </script>");
                return;
            }
            HttpPostedFile file = Request.Files["BannerImg"];
            if (file != null && file.ContentLength > 0)
            {
                string fname = file.FileName;
                if(Controller.NewBanner(BannerTitle, BannerDesc, fname))
                {
                    try
                    {
                        file.SaveAs(Server.MapPath(Path.Combine("~/Content/Images/", fname)));
                        Response.Write("<script> alert('Banner cadastrado com sucesso!') </script>");
                    }
                    catch (Exception ex)
                    {
                        string result = string.Format("<script> alert('{0}') </script>", ex);
                        Response.Write(result);
                    }
                }
                else
                {
                    Response.Write(string.Format("<script> alert('{0}') </script>", Controller.Error));
                }
            }
            else
            {
                Response.Write("<script> alert('Você enviou um arquivo inválido de imagem!') </script>");
            }
        }
    }
    protected void ValidarSessao()
    {
        if (Request.Cookies["UID"] != null)
        {
            Cookie = Request.Cookies["UID"].Value;
        }
        AdministracaoController AdminController;

        if (!(string.IsNullOrEmpty(Cookie)))
        {
            AdminController = new AdministracaoController();
            var result = AdminController.VerifyToken(Cookie);
            if (!(result.Id > 0))
            {
                Response.Redirect(RedirectUrl);
                Response.End();
            }

        }
        else
        {
            Response.Redirect(RedirectUrl);
            Response.End();
        }
    }

}