using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TramitesAlillo.DTO.General.Catalogs
{
    public class SelectCatalogs : IDisposable
    {
        public bool _disposed;

        /// <summary>
        /// Constructor necesario para la serialización
        /// </summary>
        public SelectCatalogs() { }

        /// <summary>
        /// Regresa un arreglo de las familias existentes
        /// </summary>
        [XmlElement(ElementName = "Select")]
        public Controls.Select[] SelectItems { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        ~SelectCatalogs()
        {
            Dispose(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
