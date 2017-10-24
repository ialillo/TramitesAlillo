using System;
using System.Runtime.Serialization;

namespace TramitesAlillo.DTO.General
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Result : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Constructor base requerido para la serialización
        /// </summary>
        public Result() { }

        /// <summary>
        /// Constructor para creación de objetos al vuelo
        /// </summary>
        /// <param name="success"></param>
        /// <param name="servicesMessage"></param>
        public Result(bool success, string servicesMessage)
        {
            this.Success = success;
            this.ServiceMessage = servicesMessage;
        }

        /// <summary>
        /// Describe si la llamada al servicio fué satisfactoria o no
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary>
        /// Envía el mensaje de error o exito de la llamada al servicio
        /// </summary>
        [DataMember]
        public string ServiceMessage { get; set; }

        /// <summary>
        /// Utiliza el garbage collector para destruir las instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~Result()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
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
