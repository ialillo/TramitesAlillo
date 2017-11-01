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
    }
}
