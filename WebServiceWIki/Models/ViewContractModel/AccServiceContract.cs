using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceWIki.Models.ViewContractModel
{
    [DataContract(Name ="NguoiDichVu")]
    public class AccServiceContract
    {
        [DataMember(Name ="MaNguoiDV")]
        public int idAS { get; set; }
        [DataMember(Name = "TenNguoiDV")]
        public string nameAS { get; set; }
        [DataMember(Name = "MailNguoiDV")]
        public string emailAS { get; set; }
        [DataMember(Name = "MKNguoiDV")]
        public string pwdAS { get; set; }
        [DataMember(Name = "TokenNguoiDV")]
        public string tokenString { get; set; }
        [DataMember(Name = "KichHoatNguoiDV")]
        public bool sttAS { get; set; }
    }
}