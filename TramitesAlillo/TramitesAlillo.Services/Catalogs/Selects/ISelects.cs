using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TramitesAlillo.Services.Catalogs.Selects
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISelectsManagement" in both code and config file together.
    [ServiceContract]
    public interface ISelects
    {
        /// <summary>
        /// Trae el catalogo para llenar un select de EntidadeTramite
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetEntidadTramiteList();

        /// <summary>
        /// Trae el catalogo para llenar un select de TipoTramite
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetTipoTramiteList();

        /// <summary>
        /// Trae el catalogo para llenar un select de RequerimientoTramite
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetRequerimientoTramiteList();

        /// <summary>
        /// Trae el catalogo para llenar un select de RequerimientoTramiteTipoEntrega
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetRequerimientoTramiteTipoEntregaList();
    }
}
