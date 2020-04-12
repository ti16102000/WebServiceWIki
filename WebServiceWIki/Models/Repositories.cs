using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.Business;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models
{
    public class Repositories
    {
        #region Category(6)
        public static bool CreateCate(Category cate)
        {
            if (CategoryBUS.CreateCate(cate) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            return CategoryBUS.GetAllCate();
        }
        public static Category GetCateByID(int idCate)
        {
            return CategoryBUS.GetCateByID(idCate);
        }
        public static bool UpdateCate(Category c)
        {
            if (CategoryBUS.UpdateCate(c) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            if (CategoryBUS.DelCate(idCate) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetCbbEditByIDCate(int idCate)
        {
            return CategoryBUS.GetCbbEditByIDCate(idCate);
        }
        #endregion
        #region Information
        public static bool CreateInfo(Information i)
        {
            if (InformationBUS.CreateInfo(i) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Information> GetAllInfoAdmin()
        {
            return InformationBUS.GetAllInfoAdmin();
        }
        public static List<Information> GetInfoByIDCate(int idCate)
        {
            return InformationBUS.GetInfoByIDCate(idCate);
        }
        public static List<Information> GetAllInfoByIDUser(int idUser)
        {
            return InformationBUS.GetAllInfoByIDUser(idUser);
        }
        public static List<Information> GetInfoByIDUser(int idUser)
        {
            return InformationBUS.GetInfoByIDUser(idUser);
        }
        public static List<Information> GetAllInfoUserNew()
        {
            return InformationBUS.GetAllInfoUserNew();
        }
        public static List<Information> GetAllInfoAdminHide()
        {
            return InformationBUS.GetAllInfoAdminHide();
        }
        public static Information GetInfoByID(int idIF)
        {
            return InformationBUS.GetInfoByID(idIF);
        }
        public static bool UpdateInfo(Information i)
        {
            if (InformationBUS.UpdateInfo(i) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelIF(int idIF)
        {
            if (InformationBUS.DelIF(idIF) == true)
            {
                return true;
            }
            return false;
        }
        public static bool ReadInfoNew(int idIF)
        {
            if (InformationBUS.ReadInfoNew(idIF) == true)
            {
                return true;
            }
            return false;
        }
        public static bool HideInfo(int idIF)
        {
            if (InformationBUS.HideInfo(idIF) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Information> GetInfoHideByIDUser(int idUser)
        {
            return InformationBUS.GetInfoHideByIDUser(idUser);
        }
        public static List<Information> GetAllInfoUser()
        {
            return InformationBUS.GetAllInfoUser();
        }
        public static List<Information> GetAllInfoUserHide()
        {
            return InformationBUS.GetAllInfoUserHide();
        }
        public static List<Information> GetInfoRandom()
        {
            return InformationBUS.GetInfoRandom();
        }
        public static List<Information> Get3InfoByIDCate(int idCate)
        {
            return InformationBUS.Get3InfoByIDCate(idCate);
        }
        public static List<Information> GetInfoSearch(string value)
        {
            return InformationBUS.GetInfoSearch(value);
        }
        public static Information GetInfoByToken(string token)
        {
            return InformationBUS.GetInfoByToken(token);
        }
        public static List<Information> GetAllInfoByValueSearch(string value)
        {
            return InformationBUS.GetAllInfoByValueSearch(value);
        }
        #endregion
        #region Edit Info(8)
        public static bool CreateEI(EditInfo e)
        {
            if (InformationBUS.CreateEI(e) == true)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetAllEI(int idIF)
        {
            return InformationBUS.GetAllEI(idIF);
        }
        public static bool ReadEINew(int idEI)
        {
            if (InformationBUS.ReadEINew(idEI) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelEI(int idEI)
        {
            if (InformationBUS.DelEI(idEI) == true)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetCommentByIDUser(int idIF)
        {
            return InformationBUS.GetCommentByIDUser(idIF);
        }
        public static bool DelEIByID(int idEI)
        {
            return InformationBUS.DelEIByID(idEI);
        }
        public static List<EditInfo> GetCmtNewByIDUser(int idUser)
        {
            return InformationBUS.GetCmtNewByIDUser(idUser);
        }
        public static List<EditInfo> GetCmtReadByIDUser(int idUser)
        {
            return InformationBUS.GetCmtReadByIDUser(idUser);
        }
        #endregion
        #region User(7)
        public static bool ActiveUser(int idUser)
        {
            if (UserBUS.ActiveUser(idUser) == true)
            {
                return true;
            }
            return false;
        }
        public static List<User> GetAllUser()
        {
            return UserBUS.GetAllUser();
        }
        public static int CheckRoleLogin(string mail, string pwd)
        {
            return UserBUS.CheckRoleLogin(mail, pwd);
        }
        public static int CreateUser(User u)
        {
            return UserBUS.CreateUser(u);
        }
        public static User UserLogin(string mail)
        {
            return UserBUS.UserLogin(mail);
        }
        public static int UpdateInfoUser(User u)
        {
            return UserBUS.UpdateInfoUser(u);
        }
        public static bool ChangePwd(int idUser, string pwdOld, string pwdNew)
        {
            return UserBUS.ChangePwd(idUser,pwdOld,pwdNew);
        }
        #endregion
        #region AccService
        public static bool CreateAccService(AccService a)
        {
            return AccServiceBUS.CreateAccService(a);
        }
        public static AccService AccLogin(string mail)
        {
            return AccServiceBUS.AccLogin(mail);
        }
        public static List<AccService> GetAllAS()
        {
            return AccServiceBUS.GetAllAS();
        }
        #endregion
    }
}