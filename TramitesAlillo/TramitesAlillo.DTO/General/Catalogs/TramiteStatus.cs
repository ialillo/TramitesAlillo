using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.General.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class TramiteStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public TramiteStatus() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreStatus"></param>
        /// <param name="descStatus"></param>
        /// <param name="activo"></param>
        public TramiteStatus(int id, string nombreStatus, string descStatus, bool activo)
        {
            this.Id = id;
            this.DescStatus = descStatus;
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
        public string NombreStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DescStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}
