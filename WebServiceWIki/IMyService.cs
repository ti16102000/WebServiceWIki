using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebServiceWIki.Models.ViewContractModel;

namespace WebServiceWIki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract(Name = "MyWikiService", Namespace = "WikiReference")]
    public interface IMyService
    {
        #region Category(6)
        [OperationContract(Name = "TaoDM")]
        bool CreateCategory(CategoryContract newCate);
        [OperationContract(Name = "DSDM")]
        IEnumerable<CategoryContract> GetAllCate();
        [OperationContract(Name = "LayDM")]
        CategoryContract GetCateByID(int idCate);
        [OperationContract(Name = "SuaDM")]
        bool UpdateCate(CategoryContract cate);
        [OperationContract(Name = "XoaDM")]
        bool DelCate(int idCate);
        [OperationContract(Name ="LayCBBCate")]
        IEnumerable<CategoryContract> GetCbbEditByIDCate(int idCate);
        #endregion
        #region Information
        [OperationContract(Name = "TaoTT")]
        bool CreateInfo(InformationContract newInfo);
        [OperationContract(Name = "DSTTAdmin")]
        IEnumerable<InfoViewContract> GetAllInfoAdmin();
        [OperationContract(Name ="LayTTNguoiDung")]
        IEnumerable<InfoViewContract> GetAllInfoUser();
        [OperationContract(Name = "LayTTTheoNguoiDung")]
        IEnumerable<InformationContract> GetInfoByIDUser(int idUser);
        [OperationContract(Name = "LayTTMoiNguoiDung")]
        IEnumerable<InfoViewContract> GetAllInfoUserNew();
        [OperationContract(Name = "LayTTAnNguoiDung")]
        IEnumerable<InfoViewContract> GetAllInfoUserHide();
        [OperationContract(Name ="LayTTAnAdmin")]
        IEnumerable<InfoViewContract> GetAllInfoAdminHide();
        [OperationContract(Name ="LayTTAnTheoNguoidung")]
        IEnumerable<InfoViewContract> GetInfoHideByIDUser(int idUser);
        [OperationContract(Name = "LayTTTheoDM")]
        IEnumerable<InfoViewContract> GetInfoByIDCate(int idCate);
        [OperationContract(Name = "LayHetTTTheoNguoiDung")]
        IEnumerable<InfoViewContract> GetAllInfoByIDUser(int idUser);
        [OperationContract(Name = "LayTTNgauNhien")]
        IEnumerable<InfoViewContract> GetInfoRandom();
        [OperationContract(Name = "Lay3TT")]
        IEnumerable<InfoViewContract> Get3InfoByIDCate(int idCate);
        [OperationContract(Name = "LayTT")]
        InfoViewContract GetInfoByID(int idIF);
        [OperationContract(Name = "SuaTT")]
        bool UpdateInfo(InformationContract i);
        [OperationContract(Name = "XoaTT")]
        bool DelIF(int idIF);
        [OperationContract(Name = "DocTTMoi")]
        bool ReadInfoNew(int idIF);
        [OperationContract(Name = "AnMotTT")]
        bool HideInfo(int idIF);
        [OperationContract(Name = "TimKiemTT")]
        IEnumerable<InformationContract> GetInfoSearch(string value);
        [OperationContract(Name = "TTTimKiem")]
        IEnumerable<InfoViewContract> GetAllInfoByValueSearch(string value);
        #endregion
        #region Edit Info(8)
        [OperationContract(Name = "TaoSuaTT")]
        bool CreateEI(EditInfoContract newEdit);
        [OperationContract(Name = "DSSTT")]
        IEnumerable<EditInfoViewContract> GetAllEI(int idIF);
        [OperationContract(Name = "DocSuaTTMoi")]
        bool ReadEINew(int idEI);
        [OperationContract(Name = "XoaSuaTT")]
        bool DelEI(int idEI);
        [OperationContract(Name ="LayBLNguoiDung")]
        IEnumerable<EditInfoViewContract> GetCommentByIDUser(int idIF);
        [OperationContract(Name = "XoaSuaTTTheoMaSua")]
        bool DelEIByID(int idEI);
        [OperationContract(Name ="LayBLMoiTheoNguoiDung")]
        IEnumerable<EditInfoViewContract> GetCmtNewByIDUser(int idUser);
        [OperationContract(Name = "LayBLDaXemTheoNguoiDung")]
        IEnumerable<EditInfoViewContract> GetCmtReadByIDUser(int idUser);
        #endregion
        #region User(7)
        [OperationContract(Name = "LayTatCaNguoiDung")]
        IEnumerable<UserContract> GetAllUser();
        [OperationContract(Name = "KichHoatNguoiDung")]
        bool ActiveUser(int idUser);
        [OperationContract(Name = "KiemTraNguoiDung")]
        int CheckRoleLogin(string mail, string pwd);
        [OperationContract(Name = "TaoNguoiDung")]
        int CreateUser(UserContract u);
        [OperationContract(Name = "NguoiDungDangNhap")]
        UserContract UserLogin(string mail);
        [OperationContract(Name ="CapNhatThongTin")]
        int UpdateInfoUser(UserContract u);
        [OperationContract(Name = "DoiMatKhauNguoiDung")]
        bool ChangePwd(int idUser, string pwdOld, string pwdNew);
        #endregion
        #region AccService
        [OperationContract(Name = "TaoNguoiDV")]
        bool CreateAccService(AccServiceContract a);
        [OperationContract(Name = "NguoiDVDangNhap")]
        AccServiceContract AccLogin(string mail);
        [OperationContract(Name = "DSAS")]
        IEnumerable<AccServiceContract> GetAllAS();
        #endregion
    }
}
