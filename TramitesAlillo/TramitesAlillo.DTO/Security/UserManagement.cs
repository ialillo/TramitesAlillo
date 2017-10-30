using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using TramitesAlillo.DAL;

namespace TramitesAlillo.DTO.Security
{
    public class UserManagement : IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// Metodo requerido para la serializacion
        /// </summary>
        public UserManagement() { }

        /// <summary>
        /// Representa un arreglo de usuarios loggeados
        /// </summary>
        [XmlElement(ElementName = "LoggedUser")]
        public LoggedUser[] LoggedUsers { get; set; }

        /// <summary>
        /// Trae una lista de todos los usuarios en la base de datos
        /// </summary>
        /// <returns></returns>
        public UserManagement GetUsersFromDB()
        {
            using (DBAcceso<UserManagement> usersList = new DBAcceso<UserManagement>())
            {
                return usersList.GetObject("Usuarios.ObtenUsuarios");
            }
        }

        /// <summary>
        /// Trae los perfiles activos
        /// </summary>
        /// <returns>Una instancia de SelectCatalogs que puede traer un arreglo</returns>
        public DTO.General.Catalogs.SelectCatalogs GetProfiles()
        {
            using (DBAcceso<DTO.General.Catalogs.SelectCatalogs> profilesSelect = new DBAcceso<DTO.General.Catalogs.SelectCatalogs>())
            {
                return profilesSelect.GetObject("Usuarios.ObtenPerfiles");
            }
        }

        /// <summary>
        /// Obtiene un usuario de la base de datos recibiendo el id del usuario.
        /// </summary>
        /// <param name="idUsuario">El id del usuario a obtener</param>
        /// <returns>Regresa una instancia de un usuario loggeado</returns>
        public LoggedUser GetUserById(int idUsuario)
        {
            using (DBAcceso<LoggedUser> user = new DBAcceso<LoggedUser>())
            {
                return user.GetObject("Usuarios.ObtenUsuario", idUsuario);
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="usuario">Instancia de la clase LoggedUser</param>
        /// <returns>La contraseña generada aleatoriamente</returns>
        public string SaveNewUser(LoggedUser usuario, int randomPwdLength)
        {
            string randomPassword;

            using (TramitesAlillo.Security.General.RandomPasswordGenerator rpg = new TramitesAlillo.Security.General.RandomPasswordGenerator())
            {
                randomPassword = rpg.GetRandomPassword(randomPwdLength);
                using (TramitesAlillo.Security.Encription.Encrypter enc = new TramitesAlillo.Security.Encription.Encrypter())
                {
                    string encriptedPassword = enc.Encrypt(randomPassword);
                    using (DBAcceso<LoggedUser> user = new DBAcceso<LoggedUser>())
                    {
                        string insertResult = (string)user.ExecuteScalar("Usuarios.InsertaUsuario", usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                            usuario.Usuario, encriptedPassword, usuario.Email, usuario.IdPerfil);

                        if (insertResult == "ERROR")
                        {
                            throw new System.Exception("El usuario o persona que desea registrar ya existe y se encuentra activo en el sistema.");
                        }
                    }
                }
                return randomPassword;
            }
        }

        /// <summary>
        /// Edita un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Instancia de logged user</param>
        public void SaveUser(LoggedUser usuario)
        {
            using (DBAcceso<LoggedUser> user = new DBAcceso<LoggedUser>())
            {
                user.ExecuteNonQuery("Usuarios.ActualizaUsuario", usuario.Id, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                    usuario.Email, usuario.IdPerfil);
            }
        }

        /// <summary>
        /// Desactiva un usuario existente en la base de datos.
        /// </summary>
        /// <param name="idUsuario">id del usuario a desactivar.</param>
        public void DeactivateUser(int idUsuario)
        {
            using (DBAcceso<LoggedUser> lu = new DBAcceso<LoggedUser>())
            {
                lu.ExecuteNonQuery("Usuarios.DesactivaUsuario", idUsuario);
            }
        }

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
        ~UserManagement()
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
