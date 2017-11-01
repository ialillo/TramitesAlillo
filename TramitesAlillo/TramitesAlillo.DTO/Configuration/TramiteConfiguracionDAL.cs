using System;
using TramitesAlillo.DAL;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TramitesAlillo.DTO.Configuration
{
    public class TramiteConfiguracionDAL : DBAcceso<TramiteConfiguracion>, IDisposable
    {
        private bool _disposed;

        public TramiteConfiguracionDAL() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TramiteConfiguracion GetTramiteEspecificacionList()
        {
            return GetObject("Configuracion.TramiteEspecificacionManagement");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~TramiteConfiguracionDAL()
        {
            Dispose(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
