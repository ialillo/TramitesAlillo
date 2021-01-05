using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TramitesAlillo.Services.Configuration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITramites" in both code and config file together.
    [ServiceContract]
    public interface ITramites
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Configuration.TramiteConfiguracion> GetTramiteEspecificacionList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramite"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Configuration.TramiteConfiguracion> SaveTramiteConfiguracion(int idEntidadTramite, int idTipoTramite,
            int idRequerimientoTramite, int idRequerimientoTramiteTipoEntrega, bool personaMoral, bool carga);
    }
}
