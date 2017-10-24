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
    class TipoTramite : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public TipoTramite() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreTipoTramite"></param>
        /// <param name="activo"></param>
        public TipoTramite(int id, string nombreTipoTramite, bool activo)
        {
            this.Id = id;
            this.NombreTipoTramite = nombreTipoTramite;
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
        public string NombreTipoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }

        /// <summary>
        /// Insertamos un nuevo tipo de tramite en la base de datos
        /// </summary>
        /// <param name="tipoTramite"></param>
        public void InsertTipoTramite(string tipoTramite)
        {
            using (DBAcceso<TipoTramite> tt = new DBAcceso<TipoTramite>())
            {
                tt.ExecuteNonQuery("Catalogos.TipoTramiteManagement", 1, tipoTramite);
            }
        }

        /// <summary>
        /// Traemos una lista de tipos de tramite para llenar un select
        /// </summary>
        /// <returns></returns>
        public SelectCatalogs GetTipoTramiteSelect()
        {
            using (DBAcceso<SelectCatalogs> tipoTramiteSelect = new DBAcceso<SelectCatalogs>())
            {
                return tipoTramiteSelect.GetObject("Catalogos.TipoTramiteManagement", 5);
            }
        }

        /// <summary>
        /// Desactivamos un item del catalogo de Tipos de Tramite
        /// </summary>
        /// <param name="idTipoTramite"></param>
        public void DeactivateTipoTramite(int idTipoTramite)
        {
            using (DBAcceso<TipoTramite> tt = new DBAcceso<TipoTramite>())
            {
                tt.ExecuteNonQuery("Catalogos.TipoTramiteManagement", 2, idTipoTramite);
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
        ~TipoTramite()
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
