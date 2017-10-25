using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TramitesAlillo.Services.Configuration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Tramites" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Tramites.svc or Tramites.svc.cs at the Solution Explorer and start debugging.
    public class Tramites : ITramites
    {
        public DTO.General.ResultGeneric<DTO.Configuration.TramiteEspecificacion> GetTramiteEspecificacionList()
        {
            using (DTO.General.ResultGeneric<DTO.Configuration.TramiteEspecificacion> result = new DTO.General.ResultGeneric<DTO.Configuration.TramiteEspecificacion>())
            {
                try
                {
                    using (DTO.Configuration.TramiteEspecificacion te = new DTO.Configuration.TramiteEspecificacion())
                    {
                        result.Object = te.GetTramiteEspecificacionList();
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
