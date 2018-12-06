using HideluzWebMVC.Controllers;
using System;
using System.Web;
public partial class Views_Home_Administracao_Sessao : System.Web.UI.Page
{
    private PageController PageController { get; set; }
    private const string RedirectUrl = "/Views/Home/Administracao.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        PageController = new PageController();
        if (!PageController.VerifyUserSession()) {
            Response.Redirect(RedirectUrl);
            Response.End();
        }
    }

    public string GetUsername()
    {
        return HttpContext.Current.Session["username"].ToString();
    }
}