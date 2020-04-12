using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.CommonHelper;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.DAO
{
    public class InformationDAO
    {
        public static bool CreateInfo(Information i)
        {
            try
            {
                i.token= Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                i.nameUnsigned = CommonHelper.RemoveUnicode.RemoveSign4VietnameseString(i.titleInfo);
                DBWikiEntities we = new DBWikiEntities();
                we.Information.Add(i);
                we.SaveChanges();
                return true;
                //aaaaaaaa
            }
            catch (Exception)
            {
                return false;
            }                     
        }
        public static List<Information> GetAllInfoAdmin()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.hideInfo == false && w.User.idR==1).OrderByDescending(o=>o.dayCreateInfo).ToList();
        }
        public static List<Information> GetAllInfoUserNew()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.hideInfo == false && w.newInfo == true && w.User.idR == 2).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetAllInfoUserHide()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.hideInfo == true && w.User.idR == 2).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetAllInfoUser()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.hideInfo == false && w.newInfo == false && w.User.idR == 2).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetInfoByIDCate(int idCate)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.idCate == idCate && w.hideInfo == false).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetAllInfoAdminHide()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.hideInfo == true && w.User.idR == 1).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetAllInfoByIDUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.idUser == idUser).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetInfoByIDUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.idUser == idUser && w.hideInfo == false).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static List<Information> GetInfoHideByIDUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.idUser == idUser && w.hideInfo == true).OrderByDescending(o => o.dayCreateInfo).ToList();
        }
        public static Information GetInfoByID(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.SingleOrDefault(w => w.idInfor==idIF);
        }
        public static bool UpdateInfo(Information i)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q=we.Information.SingleOrDefault(w => w.idInfor == i.idInfor);
            q.titleInfo = i.titleInfo;
            q.idCate = i.idCate;
            q.contentInfo = i.contentInfo;
            q.nameUnsigned = CommonHelper.RemoveUnicode.RemoveSign4VietnameseString(i.titleInfo);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DelIF(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            var i = we.Information.SingleOrDefault(w => w.idInfor == idIF);
            we.Information.Remove(i);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool ReadInfoNew(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q = we.Information.SingleOrDefault(w => w.idInfor == idIF);
            q.newInfo = false;
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool HideInfo(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q = we.Information.SingleOrDefault(w => w.idInfor == idIF);
            if (q.hideInfo == false)
            {
                q.hideInfo = true;
            }
            else
            {
                q.hideInfo = false;
            }
            
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<Information> GetInfoRandom()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Distinct().OrderBy(s => Guid.NewGuid()).Take(7).ToList();
        }
        public static List<Information> Get3InfoByIDCate(int idCate)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.idCate == idCate && w.hideInfo == false).OrderByDescending(o=>o.dayCreateInfo).Take(3).ToList();
        }
        public static List<Information> GetInfoSearch(string value)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.titleInfo.Contains(value) || w.nameUnsigned.Contains(value) && w.hideInfo == false).Take(7).ToList();
        }
        public static List<Information> GetAllInfoByValueSearch(string value)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.Where(w => w.titleInfo.Contains(value) || w.nameUnsigned.Contains(value) && w.hideInfo == false).ToList();
        }
        public static Information GetInfoByToken(string token)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Information.SingleOrDefault(w => w.token == token && w.hideInfo == false);
        }
    }
}