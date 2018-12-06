using HideluzWebMVC.DAO;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de AdminstracaoDAO
/// </summary>
public class AdminstracaoDAO : Connection
{
    public AdminstracaoDAO()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
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