using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.DAO
{
    public class EditInfoDAO
    {
        public static bool CreateEI(EditInfo e)
        {
            DBWikiEntities we = new DBWikiEntities();
            we.EditInfoes.Add(e);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetAllEI(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.EditInfoes.Where(w => w.idInfo == idIF).OrderByDescending(o=>o.dayCreateEI).ToList();
        }
        public static bool ReadEINew(int idEI)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q = we.EditInfoes.SingleOrDefault(s => s.idEI == idEI);
            q.newEI = false;
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DelEI(int idEI)
        {
            DBWikiEntities we = new DBWikiEntities();
            var e = we.EditInfoes.SingleOrDefault(s => s.idInfo == idEI);
            if (e == null)
            {
                return false;
            }
            we.EditInfoes.Remove(e);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetCommentByIDUser(int idIF)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.EditInfoes.Where(w => w.idInfo == idIF && w.contentEdit!=null).OrderBy(o => o.dayCreateEI).ToList();
        }
        public static bool DelEIByID(int idEI)
        {
            DBWikiEntities we = new DBWikiEntities();
            var e = we.EditInfoes.SingleOrDefault(s => s.idEI == idEI);
            we.EditInfoes.Remove(e);
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<EditInfo> GetCmtNewByIDUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.EditInfoes.Where(w => w.Information.idUser == idUser && w.newEI == true && w.contentEdit!=null).OrderByDescending(o => o.dayCreateEI).ToList();
        }
        public static List<EditInfo> GetCmtReadByIDUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.EditInfoes.Where(w => w.Information.idUser == idUser && w.newEI == false && w.contentEdit != null).OrderByDescending(o => o.dayCreateEI).ToList();
        }
    }
}