using HideluzWebMVC.Controllers;
using System;
using System.Web.UI;

public partial class Views_Home_Administracao : System.Web.UI.Page
{
    private AdministracaoController Controller { get; set; }
    private PageController PageController { get; set; }
    private const string RedirectUrl = "/Views/Home/Administracao/Sessao.aspx";
    private string Cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        Controller = new AdministracaoController();
        PageController = new PageController();

        if(PageController.VerifyUserSession())
        {
            Response.Redirect(RedirectUrl);
        }
        else
        {
            if (PageController.VerifyRequestMethod(Page.Request) == 1)
            {
                var userModel = Controller.VerifyUser(Page.Request);
                if (userModel != null)
                {
                    PageController.SetUserSession(userModel);
                    Response.Redirect(RedirectUrl);
                }
                else
                {
                    Response.Write("<script>alert('Verique seu login e senha.')</script>");
                }
            }
        }

    }
}