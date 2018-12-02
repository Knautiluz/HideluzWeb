using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Planos : System.Web.UI.Page
{
    private BannerController Controller { get; set; }
    private List<BannerModel> Banners { get; set; }
    public const string url = "../../Content/Images/Planos/";

    protected void Page_Load(object sender, EventArgs e)
    {
        Controller = new BannerController();
        Banners = Controller.SelectAllPlanBanners();
    }

    public string CarouselOneUrl()
    {
        return url + Banners.ElementAt(0).Url;
    }

    public string CarouselOneTitle()
    {
        return Banners.ElementAt(0).Title;
    }

    public string CarouselOneDesc()
    {
        return Banners.ElementAt(0).Desc;
    }

    public string CarouselTwoUrl()
    {
        return url + Banners.ElementAt(1).Url;
    }

    public string CarouselTwoTitle()
    {
        return Banners.ElementAt(1).Title;
    }

    public string CarouselTwoDesc()
    {
        return Banners.ElementAt(1).Desc;
    }

    public string CarouselThreeUrl()
    {
        return url + Banners.ElementAt(2).Url;
    }

    public string CarouselThreeTitle()
    {
        return Banners.ElementAt(2).Title;
    }

    public string CarouselThreeDesc()
    {
        return Banners.ElementAt(2).Desc;
    }
}