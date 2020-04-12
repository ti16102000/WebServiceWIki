using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.DAO;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.Business
{
    public class UserBUS
    {
        public static bool ActiveUser(int idUser)
        {
            if (UserDAO.ActiveUser(idUser)==true)
            {
                return true;
            }
            return false;
        }
        public static List<User> GetAllUser()
        {
            return UserDAO.GetAllUser();
        }
        public static int CheckRoleLogin(string mail, string pwd)
        {
            return UserDAO.CheckRoleLogin(mail, pwd);
        }
        public static int CreateUser(User u)
        {
            return UserDAO.CreateUser(u);
        }
        public static User UserLogin(string mail)
        {
            return UserDAO.UserLogin(mail);
        }
        public static int UpdateInfoUser(User u)
        {
            return UserDAO.UpdateInfoUser(u);
        }
        public static bool ChangePwd(int idUser, string pwdOld, string pwdNew)
        {
            return UserDAO.ChangePwd(idUser,pwdOld,pwdNew);
        }
    }
}