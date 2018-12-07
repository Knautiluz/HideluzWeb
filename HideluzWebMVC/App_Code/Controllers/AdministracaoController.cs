using HideluzWebMVC.DAO;
using HideluzWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HideluzWebMVC.Controllers
{
    public class AdministracaoController
    {
        private AdminstracaoDAO Administrador { get; set; }
        private UserModel UserModel { get; set; }
        public AdministracaoController()
        {
            Administrador = new AdminstracaoDAO();
            UserModel = new UserModel();
        }

        public UserModel VerifyUser(HttpRequest request)
        {
            var data = request.Form;

            string user = data["Username"];
            string pass = data["Password"];

            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return null;
            }
            else
            {
                UserModel.Username = user;
                UserModel.Password = pass;

                List<object> User = Administrador.VerifyLogin(UserModel);

                if (User.Count > 0)
                {
                    List<string> Results = (List<string>)User.ElementAt(0);
                    UserModel.Username = Results.ElementAt(2);
                    UserModel.Uid = Results.ElementAt(4);

                    return UserModel;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}