﻿using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TramitesAlillo.Services.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurity" in both code and config file together.
    [ServiceContract]
    public interface ISecurity
    {
        /// <summary>
        /// Método que autentica un usuario vs la base de datos
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        TramitesAlillo.DTO.General.Result Authenticate(TramitesAlillo.DTO.General.User user, string password);

        /// <summary>
        /// Método que cambia el password de un usuario
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        TramitesAlillo.DTO.General.Result ChangePassword(string oldPassword, string newPassword);

        /// <summary>
        /// Método que obtiene información del usuario en la sesión actual
        /// </summary>
        /// <returns>El usuario en sesión</returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        TramitesAlillo.DTO.General.ResultGeneric<TramitesAlillo.DTO.Security.LoggedUser> CurrentSessionUser();
    }
}
