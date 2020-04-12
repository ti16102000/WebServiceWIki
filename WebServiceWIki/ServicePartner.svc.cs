using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebServiceWIki.Models;
using WebServiceWIki.Models.DAO;
using WebServiceWIki.Models.ViewContractModel;

namespace WebServiceWIki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePartner" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePartner.svc or ServicePartner.svc.cs at the Solution Explorer and start debugging.
    public class ServicePartner : IServicePartner
    {
        public InformationContract GetInfo(string tokenService, string tokenInfo)
        {
            if (SecurityDAO.CheckToken(tokenService) == true)
            {
                var info = Repositories.GetInfoByToken(tokenInfo);
                return new InformationContract { idInfor = info.idInfor, contentInfo = info.contentInfo, dayCreateInfo = info.dayCreateInfo, newInfo = info.newInfo, titleInfo = info.titleInfo,token=info.token };
            }
            return null;
        }
    }
}
