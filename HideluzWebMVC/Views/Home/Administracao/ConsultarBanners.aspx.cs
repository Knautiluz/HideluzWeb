using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Administracao_ConsultarBanner : System.Web.UI.Page
{
    private BannerController Controller { get; set; }
    private List<BannerModel> Banners { get; set; }
    public const string url = "../../../Content/Images/";

    private string Cookie;
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidarSessao();

        Controller = new BannerController();
        Banners = Controller.SelectAllBanners();
    }

    public string BannerGenerator()
    {

        StringBuilder stringBuilder = new StringBuilder();
        if (Banners.Count == 0)
        {
            return "<h3 class='text-center alert-warning'>Não existem banners cadastrados.</h3>";
        }
        else
        {

            stringBuilder.Append("<div class='carousel-inner'>");
            stringBuilder.Append("<ol class='carousel-indicators'>");
            //for que gera os indicators
            for (int i = 0; i < Banners.Count; i++)
            {
                if (i == 0)
                {
                    stringBuilder.Append("<li data-target='#carouselExampleIndicators' data-slide-to='0' class='active'></li>");
                }
                else
                {
                    stringBuilder.Append(String.Format("<li data-target='#carouselExampleIndicators' data-slide-to='{0}'></li>", i));
                }
            }
            stringBuilder.Append("</ol>");

            //for que gera as imagens
            for (int i = 0; i < Banners.Count; i++)
            {
                if (i == 0)
                {
                    stringBuilder.Append("<div class='carousel-item active'>");
                }
                else
                {
                    stringBuilder.Append("<div class='carousel-item'>");
                }
                stringBuilder.Append(string.Format("<img id='carouselPictureThree' class='d-block w-100' src='{0}' alt='Third slide'>", url + Banners.ElementAt(i).Url));
                stringBuilder.Append("<div class='carousel-caption d-none d-md-block bg-menu-trans-dark border-radius-medium'>");
                stringBuilder.Append(string.Format("<h5>{0}</h5>", Banners.ElementAt(i).Title));
                stringBuilder.Append(string.Format("<p>{0}</p>", Banners.ElementAt(i).Desc));
                stringBuilder.Append("</div>");
                stringBuilder.Append("</div>");
            }
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
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