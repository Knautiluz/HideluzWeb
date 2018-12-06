using HideluzWebMVC.Models;
using System.Web;

/// <summary>
/// Descrição resumida de PageController
/// </summary>

namespace HideluzWebMVC.Controllers
{
    public class PageController
    {
        public PageController()
        {

        }

        public int VerifyRequestMethod(HttpRequest request)
        {
            if (request.HttpMethod.Equals("POST"))
            {
                return 1;
            }
            else if (request.HttpMethod.Equals("GET"))
            {
                return 2;
            }
            else
            {
                return 0;
            }

        }

        public bool VerifyUserSession()
        {
            var session = HttpContext.Current.Session;
            return (session["username"] != null);
        }

        public void SetUserSession(UserModel user)
        {
            var session = HttpContext.Current.Session;
            session["username"] = user.Username;
            session["uid"] = user.Uid;
        }
    }
}