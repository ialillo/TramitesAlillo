using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using TramitesAlillo.DAL;

namespace TramitesAlillo.DTO.Configuration
{
    public class TramiteConfiguracion : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public TramiteConfiguracion() { }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "TramiteEspecificacion")]
        public TramiteEspecificacion[] TramitesEspecificaciones { get; set; }

        /// <summary>
        /// Traemos la lista de Especificacion de tramites vigente
        /// </summary>
        /// <returns></returns>
        public TramiteConfiguracion GetTramiteEspecificacionList()
        {
            using (DBAcceso<TramiteConfiguracion> te = new DBAcceso<TramiteConfiguracion>())
            {
                return te.GetObject("Configuracion.TramiteEspecificacionManagement");
            }
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
        ~TramiteConfiguracion()
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
