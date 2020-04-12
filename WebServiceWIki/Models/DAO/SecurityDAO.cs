using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.DAO
{
    public class SecurityDAO
    {
        public static bool CheckToken(string token)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q = we.AccServices.Any(s => s.tokenString == token && s.sttAS == true);
            return q;
        }
    }
}