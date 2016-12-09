using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase="Dni Invalido";

        public DniInvalidoException(): this(mensajeBase)
        {
            
        }

        public DniInvalidoException(Exception e) :this(DniInvalidoException.mensajeBase, e)
        {
            
        }

        public DniInvalidoException(string message) :this(message, null)
        {
            
        }


        public DniInvalidoException(string message, Exception e) :base(mensajeBase + message, e)
        {
            
        }
    }
}
