using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.General
{
    [DataContract]
    public class User: Person
    {
        /// <summary>
        /// Constructor necesario para la serialización
        /// </summary>
        public User() { }

        /// <summary>
        /// Constructor basado en un usuario no autenticado
        /// </summary>
        /// <param name="usuario"></param>
        public User(string usuario)
        {
            this.Usuario = usuario;
        }

        public User(string apellidoPaterno, string apellidoMaterno, string nombre, string usuario)
        {
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.Nombre = nombre;
            this.Usuario = usuario;
        }

        /// <summary>
        /// Verifica el intento de Login de un usuario en la base de datos
        /// </summary>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        public Security.LoggedUser Authenticate(string password)
        {
            using (TramitesAlillo.Security.Encription.Encrypter enc = new TramitesAlillo.Security.Encription.Encrypter())
            {
                string encriptedPassword = enc.Encrypt(password);

                using (DAL.DBAcceso<Security.LoggedUser> loginAttempt = new DAL.DBAcceso<Security.LoggedUser>())
                {
                    return loginAttempt.GetObject("Seguridad.Autenticar", this.Usuario, encriptedPassword);
                }
            }
        }

        /// <summary>
        /// Método que cambia la contraseña de un usuario
        /// </summary>
        /// <param name="password"></param>
        public string ChangePassword(string oldPassword, string newPassword)
        {
            using (TramitesAlillo.Security.Encription.Encrypter enc = new TramitesAlillo.Security.Encription.Encrypter())
            {
                string encriptedPassword = enc.Encrypt(newPassword);
                string encriptedOldPassword = enc.Encrypt(oldPassword);

                using (DAL.DBAcceso<string> cp = new DAL.DBAcceso<string>())
                {
                    return (string)cp.ExecuteScalar("Seguridad.CambiaPassword", this.Usuario, encriptedOldPassword, encriptedPassword);
                }
            }
        }

        /// <summary>
        /// Propiedad que representa el login de un usuario en la base de datos
        /// </summary>
        [DataMember]
        public string Usuario { get; set; }
    }
}
