using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.DAO;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.Business
{
    public class AccServiceBUS
    {
        public static bool CreateAccService(AccService a)
        {
            return AccServiceDAO.CreateAccService(a);
        }
        public static AccService AccLogin(string mail)
        {
            return AccServiceDAO.AccLogin(mail);
        }
        public static List<AccService> GetAllAS()
        {
            return AccServiceDAO.GetAllAS();
        }
    }
}