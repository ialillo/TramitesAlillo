using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace TramitesAlillo.Services.Catalogs.Selects
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SelectsManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SelectsManagement.svc or SelectsManagement.svc.cs at the Solution Explorer and start debugging.
    public class Selects : ISelects
    {
        /// <summary>
        /// Trae la lista de entidades federativas a las que el usuario en sesion tiene acceso
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetEntidadTramiteList()
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    DTO.Security.LoggedUser usuario = (DTO.Security.LoggedUser)HttpContext.Current.Session["User"];

                    using (DTO.General.Catalogs.SelectCatalogosDAL sc = new DTO.General.Catalogs.SelectCatalogosDAL())
                    {
                        result.Object = sc.GetEntidadesTramite(usuario.Id);
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Trae la lista de tipos de tramites
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetTipoTramiteList()
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    using (DTO.General.Catalogs.SelectCatalogosDAL sc = new DTO.General.Catalogs.SelectCatalogosDAL())
                    {
                        result.Object = sc.GetTipoTramite();
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Trae la lista de tipos de requerimientos de tramite
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetRequerimientoTramiteList()
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    using (DTO.General.Catalogs.SelectCatalogosDAL sc = new DTO.General.Catalogs.SelectCatalogosDAL())
                    {
                        result.Object = sc.GetRequerimientoTramite();
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Trae la lista de tipos de tramites
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetRequerimientoTramiteTipoEntregaList()
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    using (DTO.General.Catalogs.SelectCatalogosDAL sc = new DTO.General.Catalogs.SelectCatalogosDAL())
                    {
                        result.Object = sc.GetRequerimientoTramiteTipoEntrega();
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }
    }
}
