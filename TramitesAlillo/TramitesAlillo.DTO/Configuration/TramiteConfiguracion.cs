using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.Configuration
{
    public class TramiteConfiguracion
    {
        /// <summary>
        /// 
        /// </summary>
        public TramiteConfiguracion() { }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "TramiteEspecificacion")]
        public TramiteEspecificacion[] TramitesEspecificaciones { get; set; }
    }
}
