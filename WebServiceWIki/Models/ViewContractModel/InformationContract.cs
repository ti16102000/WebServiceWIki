using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceWIki.Models.ViewContractModel
{
    [DataContract(Name ="ThongTin")]
    public class InformationContract
    {
        [DataMember(Name ="MaTT")]
        public int idInfor { get; set; }
        [DataMember(Name ="ChuDeTT")]
        public string titleInfo { get; set; }
        [DataMember(Name ="NoidungTT")]
        public string contentInfo { get; set; }
        [DataMember(Name ="NgayTaoTT")]
        public System.DateTime dayCreateInfo { get; set; }
        [DataMember(Name ="MaNguoiDung")]
        public int idUser { get; set; }
        [DataMember(Name ="MaDM")]
        public int idCate { get; set; }
        [DataMember(Name ="AnTT")]
        public bool hideInfo { get; set; }
        [DataMember(Name ="TTMoi")]
        public bool newInfo { get; set; }
        [DataMember(Name ="TokenTT")]
        public string token { get; set; }
        [DataMember(Name ="TenTTKhongDau")]
        public string nameUnsigned { get; set; }
    }
}