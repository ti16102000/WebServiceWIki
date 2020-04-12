using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceWIki.Models.ViewContractModel
{
    [DataContract(Name ="Danhmuc")]
    public class CategoryContract
    {
        [DataMember(Name ="MaDM")]
        public int idCate { get; set; }
        [DataMember(Name ="TenDM")]
        public string nameCate { get; set; }
    }
}