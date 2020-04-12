using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.DAO;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.Business
{
    public class CategoryBUS
    {
        public static bool CreateCate(Category cate)
        {
            if (CategoryDAO.CreateCate(cate)==true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            return CategoryDAO.GetAllCate();
        }
        public static Category GetCateByID(int idCate)
        {
            return CategoryDAO.GetCateByID(idCate);
        }
        public static bool UpdateCate(Category c)
        {
            if (CategoryDAO.UpdateCate(c)==true)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            if (CategoryDAO.DelCate(idCate)==true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetCbbEditByIDCate(int idCate)
        {
            return CategoryDAO.GetCbbEditByIDCate(idCate);
        }
    }
}