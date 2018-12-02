using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de BannerModel
/// </summary>
/// 
namespace HideluzWebMVC.Models
{
    public class BannerModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }

        public BannerModel()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}