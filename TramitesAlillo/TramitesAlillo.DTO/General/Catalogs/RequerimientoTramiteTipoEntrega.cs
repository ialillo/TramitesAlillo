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
    class RequerimientoTramiteTipoEntrega
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public RequerimientoTramiteTipoEntrega() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreTipoEntrega"></param>
        /// <param name="activo"></param>
        public RequerimientoTramiteTipoEntrega(int id, string nombreTipoEntrega, bool activo)
        {
            this.Id = id;
            this.NombreTipoEntrega = nombreTipoEntrega;
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
        public string NombreTipoEntrega { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreRequerimientoTramiteTipoEntrega"></param>
        public void InsertRequerimientoTramiteTipoEntrega(string nombreRequerimientoTramiteTipoEntrega)
        {
            using (DBAcceso<RequerimientoTramiteTipoEntrega> rtte = new DBAcceso<RequerimientoTramiteTipoEntrega>())
            {
                rtte.ExecuteNonQuery("Catalogos.RequerimientoTramiteTipoEntregaManagement", 1, nombreRequerimientoTramiteTipoEntrega);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SelectCatalogs GetRequerimientoTramiteTipoEntregaSelect()
        {
            using (DBAcceso<SelectCatalogs> rttes = new DBAcceso<SelectCatalogs>())
            {
                return rttes.GetObject("Catalogos.RequerimientoTramiteTipoEntregaManagement", 5);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRequerimientoTramiteTipoEntrega"></param>
        public void DeactivateRequerimientoTramiteTipoEntrega(int idRequerimientoTramiteTipoEntrega)
        {
            using (DBAcceso<RequerimientoTramiteTipoEntrega> rtte = new DBAcceso<RequerimientoTramiteTipoEntrega>())
            {
                rtte.ExecuteNonQuery("Catalogos.RequerimientoTramiteTipoEntregaManagement", 2, idRequerimientoTramiteTipoEntrega);
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
        ~RequerimientoTramiteTipoEntrega()
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
