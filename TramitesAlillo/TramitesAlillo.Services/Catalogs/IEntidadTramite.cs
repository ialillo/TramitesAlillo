using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TramitesAlillo.Services.Catalogs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEntidadTramite" in both code and config file together.
    [ServiceContract]
    public interface IEntidadTramite
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetEntidadTramiteSelect();
    }
}
