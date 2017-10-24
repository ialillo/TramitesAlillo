using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TramitesAlillo.Services.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Security.svc or Security.svc.cs at the Solution Explorer and start debugging.
    public class Security : ISecurity
    {
        /// <summary>
        /// Autentica un usuario en la base de datos
        /// </summary>
        /// <param name="user">Usuario a autenticar</param>
        /// <param name="password">Password a autenticar</param>
        /// <returns>Objeto de exito o fracaso</returns>
        public DTO.General.Result Authenticate(DTO.General.User user, string password)
        {
            using (DTO.General.ResultGeneric<DTO.Security.LoggedUser> result = new DTO.General.ResultGeneric<DTO.Security.LoggedUser>())
            {
                try
                {
                    /// Se hace el intento de login a la base de datos
                    result.Object = user.Authenticate(password);

                    /// Si el objeto es nulo es que no existen las credenciales proporcionadas
                    if (result.Object == null)
                    {
                        throw new TramitesAlillo.Exception.Login.LoginException("Credenciales incorrectas.");
                    }
                        /// Verificamos si la cuenta esta bloqueada
                    else if (result.Object.IntentosFallidosDeLogin < 6 && result.Object.Activo == false)
                    {
                        throw new TramitesAlillo.Exception.Login.LoginException("Cuenta bloqueada, ponte en contacto con el administrador del sistema");
                    }
                        /// Verificamos si la cuenta se bloqueo por intentos fallidos de login
                    else if (result.Object.IntentosFallidosDeLogin >= 6 && result.Object.Activo == false)
                    {
                        throw new TramitesAlillo.Exception.Login.LoginException("Cuenta bloqueada por exceder el limite de intentos erroneos, " +
                        "ponte en contacto con el administrador del sistema");
                    }
                        /// El password es erroneo y se aumenta en 1 el contador de intentos fallidos de login
                    else if(result.Object.Id == 0)
                    {
                        string plural = result.Object.IntentosFallidosDeLogin > 1 ? "s" : "";

                        throw new TramitesAlillo.Exception.Login.LoginException("Password incorrecto llevas " + result.Object.IntentosFallidosDeLogin.ToString() +
                        " intento" + plural + " fallido" + plural + ", recuerda que al sexto intento se bloquear&aacute; tu cuenta.");
                    }

                    /// Si se ha restaurado el password, o se acaban de enviar las credenciales al usuario
                    /// Se lanza el proceso para que cambien el password por uno personalizado
                    if (result.Object != null && result.Object.PasswordRestaurado == true && result.Object.Activo == true)
                    {
                        result.Success = true;
                        result.ServiceMessage = "Restaurado";

                        HttpContext.Current.Session["User"] = result.Object;

                        return new DTO.General.Result(result.Success, result.ServiceMessage);
                    }

                    result.Object.SessionID = HttpContext.Current.Session.SessionID;
                    HttpContext.Current.Session["User"] = result.Object;

                    result.Success = true;
                    result.ServiceMessage = "OK";
                }
                    /// En este caso se trata de una excepcion no esperada, se debe de enviar un correo automatico al admin del sistema 
                    /// que incluya el detella de la excepcion
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }
                return new DTO.General.Result(result.Success, result.ServiceMessage);
            }
        }

        /// <summary>
        /// Cambia la contraseña de un usuario
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns></returns>
        public DTO.General.Result ChangePassword(string oldPassword, string newPassword)
        {
            DTO.General.User user = new DTO.General.User(((DTO.Security.LoggedUser)HttpContext.Current.Session["User"]).Usuario);

            using (DTO.General.Result result = new DTO.General.Result())
            {
                string mensajeSP = string.Empty;

                try
                {
                    mensajeSP = user.ChangePassword(oldPassword, newPassword);

                    if (mensajeSP != "OK")
                    {
                        throw new TramitesAlillo.Exception.Login.LoginException("Contrase&ntilde;a no válida");
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;

                    return result;
                }

                result.Success = true;
                result.ServiceMessage = "OK";

                return result;
            }
        }

        /// <summary>
        /// Método que obtiene información del usuario en la sesión actual
        /// </summary>
        /// <returns>El usuario en sesión</returns>
        public DTO.General.ResultGeneric<DTO.Security.LoggedUser> CurrentSessionUser()
        {
            using (DTO.General.ResultGeneric<DTO.Security.LoggedUser> result = new DTO.General.ResultGeneric<DTO.Security.LoggedUser>())
            {
                try
                {
                    DTO.Security.LoggedUser lu = (DTO.Security.LoggedUser)HttpContext.Current.Session["User"];
                    DTO.Security.LoggedUser luMin = new DTO.Security.LoggedUser();

                    luMin.Nombre = lu.Nombre;
                    luMin.ApellidoPaterno = lu.ApellidoPaterno;
                    luMin.ApellidoMaterno = lu.ApellidoMaterno;
                    luMin.Perfil = lu.Perfil;
                    luMin.Email = lu.Email;

                    result.Object = luMin;
                    result.Success = true;
                    result.ServiceMessage = "OK";
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }

                return result;
            }
        }
    }
}
