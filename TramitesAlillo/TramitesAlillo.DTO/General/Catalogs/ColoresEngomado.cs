using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.General.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class ColoresEngomado
    {
        /// <summary>
        /// 
        /// </summary>
        public ColoresEngomado() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dia"></param>
        /// <param name="color"></param>
        /// <param name="terminacionPlaca"></param>
        /// <param name="activo"></param>
        public ColoresEngomado(int id, string dia, string color, string terminacionPlaca, bool activo)
        {
            this.Id = id;
            this.Dia = dia;
            this.Color = color;
            this.TerminacionPlaca = terminacionPlaca;
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
        public string Dia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TerminacionPlaca { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}
