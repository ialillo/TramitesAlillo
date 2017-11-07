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
    class EntidadTramite : IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// 
        /// </summary>
        public EntidadTramite() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreEntidad"></param>
        /// <param name="activo"></param>
        public EntidadTramite(int id, string nombreEntidad, bool activo)
        {
            this.Id = id;
            this.NombreEntidad = nombreEntidad;
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
        public string NombreEntidad { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="entidadTramite"></param>
        public void InsertEntidadesTramite(string entidadTramite)
        {
            using (DBAcceso<EntidadTramite> et = new DBAcceso<EntidadTramite>())
            {
                et.ExecuteNonQuery("Catalogos.EntidadTramiteManagement", 1, entidadTramite);
            }
        }

        /// <summary>
        /// Desactivamos una entidad del catalogo de entidades
        /// </summary>
        /// <param name="idEntidadTramite"></param>
        public void DeactivateEntidadTramite(int idEntidadTramite) 
        {
            using(DBAcceso<EntidadTramite> et = new DBAcceso<EntidadTramite>())
            {
                et.ExecuteNonQuery("Catalogos.EntidadTramiteManagement", 2, idEntidadTramite);
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
        ~EntidadTramite()
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
