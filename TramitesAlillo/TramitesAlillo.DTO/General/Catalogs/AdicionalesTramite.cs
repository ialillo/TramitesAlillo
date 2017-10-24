using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.General.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class AdicionalesTramite
    {
        /// <summary>
        /// 
        /// </summary>
        public AdicionalesTramite() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreAdicional"></param>
        /// <param name="activo"></param>
        public AdicionalesTramite(int id, string nombreAdicional, bool activo)
        {
            this.Id = id;
            this.NombreAdicional = nombreAdicional;
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
        public string NombreAdicional { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}
