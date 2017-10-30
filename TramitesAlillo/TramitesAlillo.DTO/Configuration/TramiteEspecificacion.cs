using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TramitesAlillo.DAL;

namespace TramitesAlillo.DTO.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TramiteEspecificacion
    {
        //private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public TramiteEspecificacion() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEntidadTramite"></param>
        /// <param name="idTipoTramite"></param>
        /// <param name="idRequerimientoTramite"></param>
        /// <param name="idRequerimientoTramiteTipoEntrega"></param>
        /// <param name="personaMoral"></param>
        /// <param name="carga"></param>
        /// <param name="fechaInicioVigencia"></param>
        /// <param name="fechaFinVigencia"></param>
        public TramiteEspecificacion(int idEntidadTramite, string nombreEntidadTramite, int idTipoTramite, string nombreTipoTramite,
            int idRequerimientoTramite, string nombreRequerimientoTramite, int idRequerimientoTramiteTipoEntrega, 
            string nombreRequerimientoTramiteTipoEntrega, bool personaMoral, bool carga, string fechaInicioVigencia,
            string fechaFinVigencia)
        {
            this.IdEntidadTramite = idEntidadTramite;
            this.NombreEntidadTramite = nombreEntidadTramite;
            this.IdTipoTramite = idTipoTramite;
            this.NombreTipoTramite = nombreTipoTramite;
            this.IdRequerimientoTramite = idRequerimientoTramite;
            this.NombreRequerimientoTramite = NombreRequerimientoTramite;
            this.IdRequerimientoTramiteTipoEntrega = idRequerimientoTramiteTipoEntrega;
            this.NombreRequerimientoTramiteTipoEntrega = nombreRequerimientoTramiteTipoEntrega;
            this.PersonaMoral = personaMoral;
            this.Carga = carga;
            this.FechaInicioVigencia = fechaInicioVigencia;
            this.FechaFinVigencia = fechaFinVigencia;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IdEntidadTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NombreEntidadTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IdTipoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NombreTipoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IdRequerimientoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NombreRequerimientoTramite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IdRequerimientoTramiteTipoEntrega { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NombreRequerimientoTramiteTipoEntrega { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool PersonaMoral { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Carga { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FechaInicioVigencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FechaFinVigencia { get; set; }

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
            using(DBAcceso<TramiteEspecificacion> tes = new DBAcceso<TramiteEspecificacion>())
            {
                tes.ExecuteNonQuery("Configuracion.TramiteEspecificacionManagement", 1, idEntidadTramite, idTipoTramite, idRequerimientoTramite, 
                    idRequerimientoTramiteTipoEntrega, personaMoral, carga);
            }
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
            using(DBAcceso<TramiteEspecificacion> te = new DBAcceso<TramiteEspecificacion>())
            {
                te.ExecuteNonQuery("Configuracion.TramiteEspecificacionManagement", 2, idEntidadTramite, idTipoTramite, idRequerimientoTramite, 
                    idRequerimientoTramiteTipoEntrega, personaMoral, carga);
            }

        }

        /* /// <summary>
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
        ~TramiteEspecificacion()
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
        }*/

    }
}
