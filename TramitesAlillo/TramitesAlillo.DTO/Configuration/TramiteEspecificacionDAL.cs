using System;
using TramitesAlillo.DAL;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TramitesAlillo.DTO.Configuration
{
    public class TramiteEspecificacionDAL : DBAcceso<TramiteEspecificacion>, IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public TramiteEspecificacionDAL() { }

        /// <summary>
        /// Insertamos una nueva especificacion de un tramite
        /// </summary>
        /// <param name="idEntidadTramite"></param>
        /// <param name="idTipoTramite"></param>
        /// <param name="idRequerimientoTramite"></param>
        /// <param name="idRequerimientoTramiteTipoEntrega"></param>
        /// <param name="personaMoral"></param>
        /// <param name="carga"></param>
        public void InsertTramiteEspecificacion(int idEntidadTramite, int idTipoTramite, int idRequerimientoTramite, int idRequerimientoTramiteTipoEntrega,
            bool personaMoral, bool carga)
        {
            ExecuteNonQuery("Configuracion.TramiteEspecificacionManagement", 1, idEntidadTramite, idTipoTramite, idRequerimientoTramite,
                    idRequerimientoTramiteTipoEntrega, personaMoral, carga);
        }

        /// <summary>
        /// Desactivamos un requerimiento de un tramite
        /// </summary>
        /// <param name="idEntidadTramite"></param>
        /// <param name="idTipoTramite"></param>
        /// <param name="idRequerimientoTramite"></param>
        /// <param name="idRequerimientoTramiteTipoEntrega"></param>
        /// <param name="personaMoral"></param>
        /// <param name="carga"></param>
        public void DeactivateTramiteEspecificacion(int idEntidadTramite, int idTipoTramite, int idRequerimientoTramite, int idRequerimientoTramiteTipoEntrega,
            bool personaMoral, bool carga)
        {
            ExecuteNonQuery("Configuracion.TramiteEspecificacionManagement", 2, idEntidadTramite, idTipoTramite, idRequerimientoTramite,
                    idRequerimientoTramiteTipoEntrega, personaMoral, carga);
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
        ~TramiteEspecificacionDAL()
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
