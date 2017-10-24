using System;
using System.Xml.Serialization;

namespace TramitesAlillo.DTO.Navegation
{
    public class Modulo
    {
        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public Modulo() { }

        /// <summary>
        /// Identificador del módulo ligado a la base de datos
        /// </summary>
        [XmlElement(ElementName = "IdModulo")]
        public int IdModulo { get; set; }

        /// <summary>
        /// Representa el nombre del módulo, propiedad ligada a la base de datos
        /// </summary>
        [XmlElement(ElementName = "DescModulo")]
        public string DescModulo { get; set; }

        /// <summary>
        /// Los nodos hijos de los elementos Modulo del menu
        /// </summary>
        [XmlElement(ElementName = "SubModulo")]
        public SubModulo[] SubModulos { get; set; }
    }
}
