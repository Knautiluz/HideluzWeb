using HideluzWebMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Administracao : System.Web.UI.Page
{
    private AdministracaoController Controller { get; set; }
    private const string RedirectUrl = "/Views/Home/Administracao/Sessao.aspx";
    private string Cookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidarSessao();

        if (Page.Request.HttpMethod.Equals("POST"))
        {
            var data = Request.Form;
            string user = data["Username"];
            string pass = data["Password"];
            Controller = new AdministracaoController();
            var result = Controller.VerifyUser(user, pass);
            if(result.Id > 0)
            {
                HttpCookie cookie = new HttpCookie("Session");
                cookie.Domain = Request.Url.Host;
                cookie.Expires = DateTime.Parse("30/08/2019");
                cookie.Name = "UID";
                var token = cookie.Value = Guid.NewGuid().ToString("X");
                Response.SetCookie(cookie);
                Controller.UpdateToken(token, result.Username);
                Response.Redirect(RedirectUrl);
            } else
            {
                Response.Write("<script>alert('Login ou senha inválidos!')</script>");
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
            if (result.Id > 0)
            {
                Response.Redirect(RedirectUrl);
                Response.End();
            }

        }
    }
}