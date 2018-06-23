using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.General.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class ConceptosCarga
    {
        /// <summary>
        /// 
        /// </summary>
        public ConceptosCarga() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreConceptoCarga"></param>
        /// <param name="activo"></param>
        public ConceptosCarga(int id, string nombreConceptoCarga, bool activo)
        {
            this.Id = id;
            this.NombreConceptoCarga = nombreConceptoCarga;
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
        public string NombreConceptoCarga { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}