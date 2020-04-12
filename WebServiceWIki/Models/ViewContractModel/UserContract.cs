using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceWIki.Models.ViewContractModel
{
    [DataContract(Name ="NguoiDung")]
    public class UserContract
    {
        [DataMember(Name ="MaNguoiDung")]
        public int idUser { get; set; }
        [DataMember(Name ="TenNguoiDung")]
        public string nameUser { get; set; }
        [DataMember(Name ="Mail")]
        public string email { get; set; }
        [DataMember(Name ="Matkhau")]
        public string pwd { get; set; }
        [DataMember(Name ="KichHoat")]
        public bool active { get; set; }
        [DataMember(Name ="MaQuyen")]
        public int idR { get; set; }
    }
}