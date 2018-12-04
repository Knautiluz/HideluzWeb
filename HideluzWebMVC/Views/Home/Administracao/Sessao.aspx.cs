using HideluzWebMVC.Controllers;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Home_Administracao_Sessao : System.Web.UI.Page
{
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";
    private string Cookie;
    private UserModel User;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidarSessao();
    }

    public string GetUsername()
    {
        return User.Username;
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
            User = AdminController.VerifyToken(Cookie);
            if (!(User.Id > 0))
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