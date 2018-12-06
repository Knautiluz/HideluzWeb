using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ResponseModel
/// </summary>
namespace HideluzWebMVC.Models
{
    public class ResponseModel
    {
        public string ResponseText { get; set; }
        public bool Response { get; set; }

        public ResponseModel(string text, bool response)
        {
            ResponseText = text;
            Response = response;
        }
    }
}