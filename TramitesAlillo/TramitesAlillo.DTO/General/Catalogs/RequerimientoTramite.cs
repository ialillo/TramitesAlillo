using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TramitesAlillo.DAL;

namespace TramitesAlillo.DTO.General.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class RequerimientoTramite : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public RequerimientoTramite() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requerimientoTramite"></param>
        /// <param name="activo"></param>
        public RequerimientoTramite(int id, string nombreRequerimientoTramite, bool activo)
        {
            this.Id = id;
            this.NombreRequerimientoTramite = nombreRequerimientoTramite;
            this.Activo = activo;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NombreRequerimientoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }

        /// <summary>
        /// Insertamos un nuevo requerimiento de tramite en la base de datos
        /// </summary>
        /// <param name="nombreRequerimientoTramite"></param>
        public void InsertRequerimientoTramite(string nombreRequerimientoTramite)
        {
            using (DBAcceso<RequerimientoTramite> rt = new DBAcceso<RequerimientoTramite>())
            {
                rt.ExecuteNonQuery("Catalogos.RequerimientoTramiteManagement", 1, nombreRequerimientoTramite);
            }
        }

        /// <summary>
        /// Desactivamos un requerimiento del catalogo
        /// </summary>
        /// <param name="idRequerimientoTramite"></param>
        public void DeactivateRequerimientoTramite(int idRequerimientoTramite)
        {
            using (DBAcceso<RequerimientoTramite> rt = new DBAcceso<RequerimientoTramite>())
            {
                rt.ExecuteNonQuery("Catalogos.RequerimientoTramiteManagement", 2, idRequerimientoTramite);
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
        ~RequerimientoTramite()
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
