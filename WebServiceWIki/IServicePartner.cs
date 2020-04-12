using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebServiceWIki.Models.ViewContractModel;

namespace WebServiceWIki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePartner" in both code and config file together.
    [ServiceContract(Name ="WebPartner",Namespace ="PartnerService")]
    public interface IServicePartner
    {
        [OperationContract(Name = "LayTT")]
        InformationContract GetInfo(string tokenService, string tokenInfo);
    }
}
