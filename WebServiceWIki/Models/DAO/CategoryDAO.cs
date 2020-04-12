using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.EntityModel;
using WebServiceWIki.Models.ViewContractModel;

namespace WebServiceWIki.Models.DAO
{
    public class CategoryDAO
    {
        public static bool CreateCate(Category cate)
        {
            DBWikiEntities we = new DBWikiEntities();
            we.Categories.Add(cate);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Categories.ToList();
        }
        public static Category GetCateByID(int idCate)
        {
            DBWikiEntities we = new DBWikiEntities();
            var cate = we.Categories.SingleOrDefault(s => s.idCate == idCate);
            return cate;
        }
        public static bool UpdateCate(Category c)
        {
            DBWikiEntities we = new DBWikiEntities();
            var cate = we.Categories.SingleOrDefault(s => s.idCate == c.idCate);
            cate.nameCate = c.nameCate;
            if (we.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            try
            {
                DBWikiEntities we = new DBWikiEntities();
                var cate = we.Categories.SingleOrDefault(s => s.idCate == idCate);
                we.Categories.Remove(cate);
                we.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
        }
        public static List<Category> GetCbbEditByIDCate(int idCate)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Categories.Where(w=>w.idCate!=idCate).ToList();
        }
    }
}