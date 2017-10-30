using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TramitesAlillo.DAL.Security
{
    public class UserManagement<T> : IDisposable
    {
        private bool _disposed;

        public UserManagement() { }

        /// <summary>
        /// Trae una lista de todos los usuarios en la base de datos
        /// </summary>
        /// <returns></returns>
        public T GetUsersFromDB()
        {
            using(DBAcceso<T> usersList = new DBAcceso<T>())
            {
                return usersList.GetObject("Usuarios.ObtenUsuarios");
            }
        }

        /// <summary>
        /// Trae los perfiles activos
        /// </summary>
        /// <returns></returns>
        public T GetProfiles()
        {
            using (DBAcceso<T> profilesSelect = new DBAcceso<T>())
            {
                return profilesSelect.GetObject("Usuarios.ObtenPerfiles");
            }
        }

        /// <summary>
        /// Utiliza el Garbage Collector para eliminar instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~UserManagement()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
