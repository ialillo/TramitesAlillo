using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TramitesAlillo.Services.Catalogs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EntidadTramite" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EntidadTramite.svc or EntidadTramite.svc.cs at the Solution Explorer and start debugging.
    public class EntidadTramite : IEntidadTramite
    {
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetEntidadTramiteList(int idUsuario)
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    using (DTO.General.Catalogs.SelectCatalogosDAL sc = new DTO.General.Catalogs.SelectCatalogosDAL())
                    {
                        result.Object = sc.GetEntidadesTramite(idUsuario);
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
