using System;
using System.Collections.Generic;
using System.Linq;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.DAO
{
    public class AccServiceDAO
    {
        public static bool CreateAccService(AccService a)
        {
            DBWikiEntities we = new DBWikiEntities();
            User user = we.Users.SingleOrDefault(s => s.email == a.emailAS);
            AccService service = we.AccServices.SingleOrDefault(s => s.emailAS == a.emailAS);
            if (user != null || service != null)
            {
                return false;
            }
            a.sttAS = true;
            a.tokenString = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            //a.tokenString = CommonHelper.Tokenizer.Generate(64);
            we.AccServices.Add(a);
            we.SaveChanges();
            return true;
        }
        public static AccService AccLogin(string mail)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.AccServices.SingleOrDefault(s => s.emailAS == mail);
        }
        public static List<AccService> GetAllAS()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.AccServices.ToList();
        }

    }
}