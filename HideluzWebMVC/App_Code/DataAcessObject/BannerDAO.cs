using HideluzWebMVC.DAO;
using HideluzWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de BannerDAO
/// </summary>
public class BannerDAO : Connection
{
    public BannerDAO()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public int InsertBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("INSERT INTO `tbl_banners_index` (`titulo`, `desc`, `url`) VALUES ('{0}', '{1}', '{2}')", banner.Title, banner.Desc, banner.Url);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            if (DataConnection != null)
            {
                CloseDatabase();
            }
        }
        return affectedRows;
    }
    public int InsertPlanBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("INSERT INTO `tbl_banners_plans` (`titulo`, `desc`, `url`) VALUES ('{0}', '{1}', '{2}')", banner.Title, banner.Desc, banner.Url);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            if (DataConnection != null)
            {
                CloseDatabase();
            }
        }
        return affectedRows;
    }
    public int UpdateBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("UPDATE `tbl_banners_index` SET `titulo` = '{0}', `desc` = '{1}', `url` = '{2}' where `url` = '{3}' ", banner.Title, banner.Desc, banner.Url, banner.Id);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            affectedRows = 0;
            throw e;
        }
        finally
        {
            CloseDatabase();
        }
        return affectedRows;
    }

    public int UpdatePlanBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("UPDATE `tbl_banners_plans` SET `titulo` = '{0}', `desc` = '{1}', `url` = '{2}' where `url` = '{3}' ", banner.Title, banner.Desc, banner.Url, banner.Id);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            affectedRows = 0;
            throw e;
        }
        finally
        {
            CloseDatabase();
        }
        return affectedRows;
    }

    public int DeleteBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("DELETE FROM tbl_banners_index WHERE `url` = '{0}' ", banner.Url);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (DataConnection != null)
            {
                CloseDatabase();
            }
        }
        return affectedRows;
    }
    public int DeletePlanBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("DELETE FROM tbl_banners_plans WHERE `url` = '{0}' ", banner.Url);
            affectedRows = ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (DataConnection != null)
            {
                CloseDatabase();
            }
        }
        return affectedRows;
    }
    public List<object> ReturnAllBanners()
    {
        try
        {
            OpenDatabase();
            string sql = "SELECT * FROM `tbl_banners_index`";
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
    public List<object> ReturnAllPlanBanners()
    {
        try
        {
            OpenDatabase();
            string sql = "SELECT * FROM `tbl_banners_plans`";
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
    public int SearchBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("SELECT * FROM `tbl_banners_index` WHERE `url` = '{0}' ", banner.Url);
            affectedRows = ExecuteScalar(sql);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            CloseDatabase();
        }
        return affectedRows;
    }
    public int SearchPlanBanner(BannerModel banner)
    {
        int affectedRows;
        try
        {
            OpenDatabase();
            string sql = string.Format("SELECT * FROM `tbl_banners_plans` WHERE `url` = '{0}' ", banner.Url);
            affectedRows = ExecuteScalar(sql);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            CloseDatabase();
        }
        return affectedRows;
    }
}