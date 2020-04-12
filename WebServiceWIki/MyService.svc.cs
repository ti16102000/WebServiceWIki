using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebServiceWIki.Models;
using WebServiceWIki.Models.EntityModel;
using WebServiceWIki.Models.ViewContractModel;

namespace WebServiceWIki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public AccServiceContract AccLogin(string mail)
        {
            var a = Repositories.AccLogin(mail);
            return new AccServiceContract { idAS = a.idAS, emailAS = a.emailAS, nameAS = a.nameAS, pwdAS = a.pwdAS, sttAS = a.sttAS, tokenString = a.tokenString };
        }

        public bool ActiveUser(int idUser)
        {
            if (Repositories.ActiveUser(idUser) == true)
            {
                return true;
            }
            return false;
        }

        public bool ChangePwd(int idUser, string pwdOld, string pwdNew)
        {
            return Repositories.ChangePwd(idUser, pwdOld, pwdNew);
        }

        public int CheckRoleLogin(string mail, string pwd)
        {
            return Repositories.CheckRoleLogin(mail, pwd);
        }

        public bool CreateAccService(AccServiceContract a)
        {
            var acc = new AccService { emailAS = a.emailAS, pwdAS = a.pwdAS, nameAS = a.nameAS };
            return Repositories.CreateAccService(acc);
        }

        public bool CreateCategory(CategoryContract newCate)
        {
            Category cate = new Category
            {
                nameCate = newCate.nameCate
            };
            if (Repositories.CreateCate(cate) == true)
            {
                return true;
            }
            return false;
        }

        public bool CreateEI(EditInfoContract newEdit)
        {
            EditInfo e = new EditInfo { contentEdit = newEdit.contentEdit, idInfo = newEdit.idInfo, idUser = newEdit.idUser,newEI=newEdit.newEI };
            if (Repositories.CreateEI(e) == true)
            {
                return true;
            }
            return false;
        }

        public bool CreateInfo(InformationContract newIF)
        {
            Information i = new Information { idCate = newIF.idCate, idUser = newIF.idUser, titleInfo = newIF.titleInfo, contentInfo = newIF.contentInfo, hideInfo = newIF.hideInfo, newInfo=newIF.newInfo,token=newIF.token};
            if (Repositories.CreateInfo(i) == true)
            {
                return true;
            }
            return false;
        }

        public int CreateUser(UserContract u)
        {
            var user = new User { nameUser = u.nameUser, email = u.email, pwd = u.pwd };
            return Repositories.CreateUser(user);
        }

        public bool DelCate(int idCate)
        {
            if (Repositories.DelCate(idCate) == true)
            {
                return true;
            }
            return false;
        }

        public bool DelEI(int idEI)
        {
            if (Repositories.DelEI(idEI) == true)
            {
                return true;
            }
            return false;
        }

        public bool DelEIByID(int idEI)
        {
            return Repositories.DelEIByID(idEI);
        }

        public bool DelIF(int idIF)
        {
            if (Repositories.DelIF(idIF) == true)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<InfoViewContract> Get3InfoByIDCate(int idCate)
        {
            var ls = Repositories.Get3InfoByIDCate(idCate).Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token=s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<AccServiceContract> GetAllAS()
        {
            return Repositories.GetAllAS().Select(s => new AccServiceContract { emailAS=s.emailAS,idAS=s.idAS,nameAS=s.nameAS,pwdAS=s.pwdAS,sttAS=s.sttAS,tokenString=s.tokenString}).ToList();
        }

        public IEnumerable<CategoryContract> GetAllCate()
        {
            var ls = Repositories.GetAllCate().Select(s => new CategoryContract { idCate = s.idCate, nameCate = s.nameCate });
            return ls;
        }

        public IEnumerable<EditInfoViewContract> GetAllEI(int idIF)
        {
            var ls = Repositories.GetAllEI(idIF).Select(s => new EditInfoViewContract
            {
                active = s.User.active,
                contentEdit = s.contentEdit,
                dayCreateEI = s.dayCreateEI,
                email = s.User.email,
                idEI = s.idEI,
                idInfo = s.idInfo,
                idUser = s.idUser,
                nameUser = s.User.nameUser,
                newEI = s.newEI
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoAdmin()
        {
            var ls = Repositories.GetAllInfoAdmin().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoAdminHide()
        {
            var ls = Repositories.GetAllInfoAdminHide().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoByIDUser(int idUser)
        {
            var ls = Repositories.GetAllInfoByIDUser(idUser).Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoByValueSearch(string value)
        {
            var ls = Repositories.GetAllInfoByValueSearch(value).Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoUser()
        {
            var ls = Repositories.GetAllInfoUser().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoUserHide()
        {
            var ls = Repositories.GetAllInfoUserHide().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetAllInfoUserNew()
        {
            var ls = Repositories.GetAllInfoUserNew().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<UserContract> GetAllUser()
        {
            return Repositories.GetAllUser().Select(s => new UserContract { idUser = s.idUser, active = s.active, email = s.email, idR = s.idR, nameUser = s.nameUser, pwd=s.pwd });
        }

        public CategoryContract GetCateByID(int idCate)
        {
            var cate = Repositories.GetCateByID(idCate);
            return new CategoryContract { idCate = cate.idCate, nameCate = cate.nameCate };
        }

        public IEnumerable<CategoryContract> GetCbbEditByIDCate(int idCate)
        {
            var ls = Repositories.GetCbbEditByIDCate(idCate).Select(s => new CategoryContract { idCate = s.idCate, nameCate = s.nameCate });
            return ls;
        }

        public IEnumerable<EditInfoViewContract> GetCmtNewByIDUser(int idUser)
        {
            var ls = Repositories.GetCmtNewByIDUser(idUser).Select(s => new EditInfoViewContract
            {
                active = s.User.active,
                contentEdit = s.contentEdit,
                dayCreateEI = s.dayCreateEI,
                email = s.User.email,
                idEI = s.idEI,
                idInfo = s.idInfo,
                idUser = s.idUser,
                nameUser = s.User.nameUser,
                newEI = s.newEI
            }).ToList();
            return ls;
        }

        public IEnumerable<EditInfoViewContract> GetCmtReadByIDUser(int idUser)
        {
            var ls = Repositories.GetCmtReadByIDUser(idUser).Select(s => new EditInfoViewContract
            {
                active = s.User.active,
                contentEdit = s.contentEdit,
                dayCreateEI = s.dayCreateEI,
                email = s.User.email,
                idEI = s.idEI,
                idInfo = s.idInfo,
                idUser = s.idUser,
                nameUser = s.User.nameUser,
                newEI = s.newEI
            }).ToList();
            return ls;
        }

        public IEnumerable<EditInfoViewContract> GetCommentByIDUser(int idIF)
        {
            var ls = Repositories.GetCommentByIDUser(idIF).Select(s => new EditInfoViewContract
            {
                active = s.User.active,
                contentEdit = s.contentEdit,
                dayCreateEI = s.dayCreateEI,
                email = s.User.email,
                idEI = s.idEI,
                idInfo = s.idInfo,
                idUser = s.idUser,
                nameUser = s.User.nameUser,
                newEI = s.newEI
            }).ToList();
            return ls;
        }

        public InfoViewContract GetInfoByID(int idIF)
        {
            var info = Repositories.GetInfoByID(idIF);
            return new InfoViewContract
            {
                contentInfo = info.contentInfo,
                dayCreateInfo = info.dayCreateInfo,
                hideInfo = info.hideInfo,
                idCate = info.idCate,
                idInfor = info.idInfor,
                idUser = info.idUser,
                newInfo = info.newInfo,
                titleInfo = info.titleInfo,
                active=info.User.active,
                email=info.User.email,
                nameCate=info.Category.nameCate,
                token = info.token,
                nameUser =info.User.nameUser
            };
        }

        public IEnumerable<InfoViewContract> GetInfoByIDCate(int idCate)
        {
            var ls = Repositories.GetInfoByIDCate(idCate).Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InformationContract> GetInfoByIDUser(int idUser)
        {
            var ls = Repositories.GetInfoByIDUser(idUser).Select(s => new InformationContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                hideInfo = s.hideInfo,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetInfoHideByIDUser(int idUser)
        {
            var ls = Repositories.GetInfoHideByIDUser(idUser).Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InfoViewContract> GetInfoRandom()
        {
            var ls = Repositories.GetInfoRandom().Select(s => new InfoViewContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                active = s.User.active,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                email = s.User.email,
                hideInfo = s.hideInfo,
                nameCate = s.Category.nameCate,
                nameUser = s.User.nameUser,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public IEnumerable<InformationContract> GetInfoSearch(string value)
        {
            var ls = Repositories.GetInfoSearch(value).Select(s => new InformationContract
            {
                idInfor = s.idInfor,
                idUser = s.idUser,
                idCate = s.idCate,
                contentInfo = s.contentInfo,
                dayCreateInfo = s.dayCreateInfo,
                hideInfo = s.hideInfo,
                newInfo = s.newInfo,
                token = s.token,
                titleInfo = s.titleInfo
            }).ToList();
            return ls;
        }

        public bool HideInfo(int idIF)
        {
            if (Repositories.HideInfo(idIF) == true)
            {
                return true;
            }
            return false;
        }

        public bool ReadEINew(int idEI)
        {
            if (Repositories.ReadEINew(idEI) == true)
            {
                return true;
            }
            return false;
        }

        public bool ReadInfoNew(int idIF)
        {
            if (Repositories.ReadInfoNew(idIF) == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCate(CategoryContract cate)
        {
            Category c = new Category();
            c.idCate = cate.idCate;
            c.nameCate = cate.nameCate;
            if (Repositories.UpdateCate(c) == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdateInfo(InformationContract i)
        {
            Information info = new Information();
            info.titleInfo = i.titleInfo;
            info.idCate = i.idCate;
            info.contentInfo = i.contentInfo;
            info.idInfor=i.idInfor;
            if (Repositories.UpdateInfo(info) == true)
            {
                return true;
            }
            return false;
        }

        public int UpdateInfoUser(UserContract u)
        {
            var user = new User { idUser = u.idUser, nameUser = u.nameUser, email = u.email };
            return Repositories.UpdateInfoUser(user);
        }

        public UserContract UserLogin(string mail)
        {
            var user = Repositories.UserLogin(mail);
            return new UserContract { idUser = user.idUser, nameUser = user.nameUser, email = user.email, active = user.active, idR = user.idR, pwd = user.pwd };
        }
    }

}
