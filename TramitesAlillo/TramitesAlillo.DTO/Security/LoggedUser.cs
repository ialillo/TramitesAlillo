﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TramitesAlillo.DTO.Security
{
    /// <summary>
    /// Representa un usuario loggeado en el sistema
    /// </summary>
    [DataContract]
    public class LoggedUser : General.User
    {
        /// <summary>
        /// Constructor necesario para la serialización
        /// </summary>
        public LoggedUser() { }

        /// <summary>
        /// Constructor basado en un usuario no autenticado
        /// </summary>
        /// <param name="usuario"></param>
        public LoggedUser(General.User user) : base(user.Usuario) { }

        /// <summary>
        /// Constructor para crear un nuevo usuario.
        /// </summary>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <param name="nombre"></param>
        /// <param name="usuario"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        public LoggedUser(General.User user, string email, int idPerfil, int intentosFallidosDeLogin, bool passwordRestaurado, bool activo) :
            base(user.ApellidoPaterno, user.ApellidoMaterno, user.Nombre, user.Usuario)
        {
            this.Email = email;
            this.IdPerfil = IdPerfil;
            this.IntentosFallidosDeLogin = intentosFallidosDeLogin;
            this.PasswordRestaurado = passwordRestaurado;
            this.Activo = activo;
        }

        /// <summary>
        /// Representa el id unico de la sesión del usuario
        /// </summary>
        [DataMember]
        public string SessionID { get; set; }

        /// <summary>
        /// Representa el id del usuario en la base de datos
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Representa el nombre completo del usuario Loggeado
        /// </summary>
        [DataMember]
        public int IdPerfil { get; set; }

        /// <summary>
        /// Representa el perfil del usuario Loggeado
        /// </summary>
        [DataMember]
        public string Perfil { get; set; }

        /// <summary>
        /// Representa el email del usuario Loggeado
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Bandera para saber el numero de intentos fallidos de login de un usuario
        /// </summary>
        [DataMember]
        public int IntentosFallidosDeLogin { get; set; }

        /// <summary>
        /// Bandera para saber si el password del usuario ha sido restaurado
        /// </summary>
        [DataMember]
        public bool PasswordRestaurado { get; set; }

        /// <summary>
        /// Bandera para saber si el usuario esta activo o no
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}
