using System;

namespace Login.Exceptions
{
    public class ExceptionLogin : Exception
    {
       public ExceptionLogin(string mensagem) : base(mensagem) { }
    }
}
