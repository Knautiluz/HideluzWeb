﻿using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Administracao_AlterarBanner : System.Web.UI.Page
{
    private BannerController Controller { get; set; }
    public List<BannerModel> Banners { get; set; }
    public const string url = "../../../Content/Images/Planos/";
    private string Cookie;
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidarSessao();

        Controller = new BannerController();
        Banners = Controller.SelectAllPlanBanners();

        if (Page.Request.HttpMethod.Equals("POST"))
        {

            //instantiate index controoler
            BannerController Controller = new BannerController();

            var data = Request.Form;
            string BannerTitle = data["BannerTitle"];
            string BannerDesc = data["BannerDesc"];
            string BannerUrl = data["BannerUrl"];
            if (string.IsNullOrEmpty(BannerTitle) || string.IsNullOrEmpty(BannerDesc) || string.IsNullOrEmpty(BannerUrl))
            {
                Response.Write("<script> alert('Todos os campos são obrigatórios!') </script>");
                return;
            }
            HttpPostedFile file = Request.Files["BannerImg"];
            if (file != null && file.ContentLength > 0)
            {
                string fname = file.FileName;
                if (Controller.UpdatePlanBanner(BannerTitle, BannerDesc, fname, BannerUrl))
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
    public string BannerGenerator()
    {

        StringBuilder stringBuilder = new StringBuilder();
        if (Banners.Count == 0)
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