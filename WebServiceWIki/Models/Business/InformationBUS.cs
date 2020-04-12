using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.DAO;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.Business
{
    public class InformationBUS
    {
        public static bool CreateInfo(Information i)
        {
            if (InformationDAO.CreateInfo(i)==true)
            {
                return true;
            }
            return false;
        }
        public static List<Information> GetAllInfoAdmin()
        {
            return InformationDAO.GetAllInfoAdmin();
        }
        public static List<Information> GetAllInfoUserNew()
        {
            return InformationDAO.GetAllInfoUserNew();
        }
        public static List<Information> GetAllInfoAdminHide()
        {
            return InformationDAO.GetAllInfoAdminHide();
        }
        public static List<Information> GetInfoByIDCate(int idCate)
        {
            return InformationDAO.GetInfoByIDCate(idCate);
        }
        public static List<Information> GetAllInfoByIDUser(int idUser)
        {
            return InformationDAO.GetAllInfoByIDUser(idUser);
        }
        public static List<Information> GetInfoByIDUser(int idUser)
        {
            return InformationDAO.GetInfoByIDUser(idUser);
        }
        public static List<Information> GetInfoHideByIDUser(int idUser)
        {
            return InformationDAO.GetInfoHideByIDUser(idUser);
        }
        public static List<Information> GetAllInfoUser()
        {
            return InformationDAO.GetAllInfoUser();
        }
        public static List<Information> GetAllInfoUserHide()
        {
            return InformationDAO.GetAllInfoUserHide();
        }
        public static Information GetInfoByID(int idIF)
        {
            return InformationDAO.GetInfoByID(idIF);
        }
        public static List<Information> GetInfoRandom()
        {
            return InformationDAO.GetInfoRandom();
        }
        public static List<Information> Get3InfoByIDCate(int idCate)
        {
            return InformationDAO.Get3InfoByIDCate(idCate);
        }
        public static List<Information> GetInfoSearch(string value)
        {
            return InformationDAO.GetInfoSearch(value);
        }
        public static Information GetInfoByToken(string token)
        {
            return InformationDAO.GetInfoByToken(token);
        }
        public static List<Information> GetAllInfoByValueSearch(string value)
        {
            return InformationDAO.GetAllInfoByValueSearch(value);
        }
        public static bool UpdateInfo(Information i)
        {
            if (InformationDAO.UpdateInfo(i)==true)
            {
                return true;
            }
            return false;
        }
        public static bool DelIF(int idIF)
        {
            if (InformationDAO.DelIF(idIF)==true)
            {
                return true;
            }
            return false;
        }
        public static bool ReadInfoNew(int idIF)
        {
            if (InformationDAO.ReadInfoNew(idIF)==true)
            {
                return true;
            }
            return false;
        }
        public static bool HideInfo(int idIF)
        {
            if (InformationDAO.HideInfo(idIF) == true)
            {
                return true;
            }
            return false;
        }
        public static bool CreateEI(EditInfo e)
        {
            if (EditInfoDAO.CreateEI(e)==true)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetAllEI(int idIF)
        {
            return EditInfoDAO.GetAllEI(idIF);
        }
        public static bool ReadEINew(int idEI)
        {
            if (EditInfoDAO.ReadEINew(idEI)==true)
            {
                return true;
            }
            return false;
        }
        public static bool DelEI(int idEI)
        {
            if (EditInfoDAO.DelEI(idEI)==true)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetCommentByIDUser(int idIF)
        {
            return EditInfoDAO.GetCommentByIDUser(idIF);
        }
        public static bool DelEIByID(int idEI)
        {
            return EditInfoDAO.DelEIByID(idEI);
        }
        public static List<EditInfo> GetCmtNewByIDUser(int idUser)
        {
            return EditInfoDAO.GetCmtNewByIDUser(idUser);
        }
        public static List<EditInfo> GetCmtReadByIDUser(int idUser)
        {
            return EditInfoDAO.GetCmtReadByIDUser(idUser);
        }
    }
}