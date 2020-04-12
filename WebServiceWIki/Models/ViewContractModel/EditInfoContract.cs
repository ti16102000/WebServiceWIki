using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceWIki.Models.ViewContractModel
{
    [DataContract(Name = "SuaTT")]
    public class EditInfoContract
    {
        [DataMember(Name = "MaSuaTT")]
        public int idEI { get; set; }
        [DataMember(Name ="MaTT")]
        public int idInfo { get; set; }
        [DataMember(Name ="NoidundSua")]
        public string contentEdit { get; set; }
        [DataMember(Name ="NgaySua")]
        public System.DateTime dayCreateEI { get; set; }
        [DataMember(Name ="MaNguoiDung")]
        public int idUser { get; set; }
        [DataMember(Name ="SuaTTMoi")]
        public bool newEI { get; set; }
        
    }
}