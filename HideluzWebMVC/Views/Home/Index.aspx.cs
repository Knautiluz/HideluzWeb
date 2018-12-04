using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Default : System.Web.UI.Page
{
    private BannerController Controller { get; set; }
    private List<BannerModel> Banners { get; set; }
    public const string url = "../../Content/Images/";

    protected void Page_Load(object sender, EventArgs e)
    {
        Controller = new BannerController();
        Banners = Controller.SelectAllBanners();
    }
    public string BannerGenerator()
    {
        StringBuilder stringBuilder = new StringBuilder();
        if(Banners.Count == 0)
        {
            return "<h3 class='text-center alert-warning'>Não existem Banners cadastrados.</h3>";
        }
        else
        {
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
            return stringBuilder.ToString();
        }
    }
}