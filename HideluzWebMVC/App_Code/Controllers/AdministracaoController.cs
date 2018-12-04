using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HideluzWebMVC.Controllers
{
    public class AdministracaoController
    {
        private AdminstracaoDAO Administrador { get; set; }
        private UserModel Login {get; set;}

        public AdministracaoController()
        {
            Administrador = new AdminstracaoDAO();
            Login = new UserModel();
        }

        public UserModel VerifyUser(string user, string pass)
        {
            Login.Username = user;
            Login.Password = pass;

            List<object> User = Administrador.VerifyLogin(Login);

            if(User.Count > 0)
            {
                List<string> Results = (List<string>)User.ElementAt(0);
                Login.Id = int.Parse(Results.ElementAt(0));
                Login.Name = Results.ElementAt(1);
                Login.Username = Results.ElementAt(2);
                Login.Password = Results.ElementAt(3);
                Login.Uid = Results.ElementAt(4);
                return Login;
            }
            else
            {
                return Login;
            }
        }

        public UserModel VerifyToken(string token)
        {
            Login.Uid = token;
            List<object> Token = Administrador.VerifyToken(Login);
            if (Token.Count > 0)
            {
                List<string> Results = (List<string>)Token.ElementAt(0);
                Login.Id = int.Parse(Results.ElementAt(0));
                Login.Name = Results.ElementAt(1);
                Login.Username = Results.ElementAt(2);
                Login.Password = Results.ElementAt(3);
                Login.Uid = Results.ElementAt(4);
                return Login;
            }
            else
            {
                return Login;
            }
        }

        public int UpdateToken(string token, string username)
        {
            Login.Uid = token;
            Login.Username = username;
            return Administrador.UpdateToken(Login);
        }
    }
}