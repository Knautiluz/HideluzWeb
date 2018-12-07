using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// Descrição resumida de AdminstracaoDAO
/// </summary>
namespace HideluzWebMVC.DAO
{
    public class AdminstracaoDAO : Connection
    {
        public AdminstracaoDAO()
        {

        }
        public List<object> VerifyLogin(UserModel login)
        {
            try
            {
                OpenDatabase();
                string sql = string.Format("SELECT * FROM `tbl_users` WHERE `usuario` = '{0}' AND `senha` = '{1}'", login.Username, login.Password);
                return ExecuteQuery(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseDatabase();
            }
        }
    }
}