using HideluzWebMVC.Controllers;
using System;

public partial class Views_Home_Cadastro : System.Web.UI.Page
{
    private PageController PageController { get; set; }
    private BannerController BannerController { get; set; }

    private const string RedirectUrl = "/Views/Home/Administracao.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        PageController = new PageController();

        if(PageController.VerifyUserSession())
        {
            if (PageController.VerifyRequestMethod(Request) == 1)
            {
                BannerController = new BannerController();
                var result = BannerController.NewBanner(Request, Page);

                if (result.Response) {

                    Response.Write(string.Format("<script>alert('{0}')</script>", result.ResponseText));
                }
                else
                {
                    Response.Write(string.Format("<script>alert('{0}')", result.ResponseText));
                }
            }
        }
        else
        {
            Response.Redirect(RedirectUrl);
            Response.End();
        }
    }
}