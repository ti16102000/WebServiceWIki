using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceWIki.Models.EntityModel;

namespace WebServiceWIki.Models.DAO
{
    public class UserDAO
    {
        public static User GetUserByID(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Users.SingleOrDefault(s => s.idUser == idUser);
        }
        public static bool ActiveUser(int idUser)
        {
            DBWikiEntities we = new DBWikiEntities();
            var q = we.Users.SingleOrDefault(s => s.idUser == idUser);
            if (q.active == true)
            {
                q.active = false;
            }
            else
            {
                q.active = true;
            }       
            if (we.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<User> GetAllUser()
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Users.Where(w=>w.idR==2).ToList();
        }
        public static int CheckRoleLogin(string mail, string pwd)
        {
            DBWikiEntities we = new DBWikiEntities();
            var ad = we.Users.SingleOrDefault(s => s.email == mail && s.pwd == pwd && s.active == true && s.idR==1);
            if (ad != null)
            {
                return 1;
            }
            var user = we.Users.SingleOrDefault(s => s.email == mail && s.pwd == pwd && s.active == true && s.idR == 2);
            var service = we.AccServices.SingleOrDefault(s => s.emailAS == mail && s.pwdAS == pwd && s.sttAS == true);
            if (user != null)
            {
                return 2;
            }
            if (service != null)
            {
                return 3;
            }
            return 0;
        }
        public static int CreateUser(User u)
        {
            DBWikiEntities we = new DBWikiEntities();
            var user=we.Users.SingleOrDefault(s => s.email == u.email);
            var service = we.AccServices.SingleOrDefault(s => s.emailAS == u.email);
            if(user!=null || service != null)
            {
                return 0;
            }
            u.active = true;
            u.idR = 2;
            we.Users.Add(u);
            we.SaveChanges();
            return 1;
        }
        public static User UserLogin(string mail)
        {
            DBWikiEntities we = new DBWikiEntities();
            return we.Users.SingleOrDefault(s => s.email == mail);
        }
        public static int UpdateInfoUser(User u)
        {
            DBWikiEntities we = new DBWikiEntities();
            var mail = we.Users.SingleOrDefault(s => s.email == u.email && s.idUser != u.idUser);
            var service = we.AccServices.SingleOrDefault(s => s.emailAS == u.email);
            if (mail != null || service!=null)
            {
                return 0;
            }
            var user = we.Users.SingleOrDefault(s => s.idUser == u.idUser);
            user.nameUser = u.nameUser;
            user.email = u.email;
            we.SaveChanges();
            return 1;
        }
        public static bool ChangePwd(int idUser, string pwdOld, string pwdNew)
        {
            DBWikiEntities we = new DBWikiEntities();
            var pass = we.Users.SingleOrDefault(s => s.idUser == idUser && s.pwd == pwdOld);
            if (pass == null)
            {
                return false;
            }
            var user = we.Users.SingleOrDefault(s => s.idUser == idUser);
            user.pwd = pwdNew;
            we.SaveChanges();
            return true;
        }
    }
}