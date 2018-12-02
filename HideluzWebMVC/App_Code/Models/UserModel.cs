using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de LoginModel
/// </summary>
namespace HideluzWebMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string Uid { get; set; }

        public UserModel()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}