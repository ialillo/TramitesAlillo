using System;

namespace TramitesAlillo.Exception.Login
{
    public class LoginException : System.Exception
    {
        public LoginException() { }

        public LoginException(string message) : base(message) { }

        public LoginException(string message, System.Exception inner) : base(message, inner) { }
    }
}