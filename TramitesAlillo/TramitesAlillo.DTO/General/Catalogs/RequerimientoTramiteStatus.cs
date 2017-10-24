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
    class RequerimientoTramiteStatus : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public RequerimientoTramiteStatus() { }

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
        public bool Activo { get; set; }

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
        ~RequerimientoTramiteStatus()
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
