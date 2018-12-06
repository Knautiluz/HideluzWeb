using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Views_Home_Administracao_DeletarBanner : System.Web.UI.Page
{
    private BannerController Controller { get; set; }
    private PageController PageController { get; set; }
    public List<BannerModel> Banners { get; set; }
    public const string Url = "../../../Content/Images/";
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        PageController = new PageController();
        if(PageController.VerifyUserSession())
        {
            Controller = new BannerController();
            Banners = Controller.SelectAllBanners();

            if(PageController.VerifyRequestMethod(Request) == 1)
            {
                var result = Controller.DeleteBanner(Request, Page);
                if (result.Response)
                {
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write(string.Format("<script>alert('{0}')</script>", result.ResponseText));
                }
            }

        }
        else
        {
            Response.Redirect(RedirectUrl);
            Response.End();
        }
    }

    public string BannerGenerator()
    {

        StringBuilder stringBuilder = new StringBuilder();
        if (Banners.Count == 0)
        {
            return null;
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
                stringBuilder.Append(string.Format("<img id='carouselPictureThree' class='d-block w-100' src='{0}' alt='Third slide'>", Url + Banners.ElementAt(i).Url));
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
}