using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de BannerController
/// </summary>
public class BannerController
{
    public string Error { get; set; }
    private BannerModel Banner { get; set; }
    private BannerDAO DataAccessObject { get; set; }

    public BannerController()
    {
        Banner = new BannerModel();
        DataAccessObject = new BannerDAO();
    }

    public bool NewBanner(string title, string desc, string url)
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
    public bool NewPlanBanner(string title, string desc, string url)
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
}