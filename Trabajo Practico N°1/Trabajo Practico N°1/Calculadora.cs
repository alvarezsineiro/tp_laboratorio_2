using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_N_1
{
    class Calculadora
    {
        public Calculadora()
        { 

        }

        /// <summary>
        ///  Metodo que se encarga de realizar las operaciones. Su valor de retorno será del tipo double. Si no puede operar retornará 0. 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operardor"></param>
        /// <returns></returns>
        public double operar(Numero numero1,Numero numero2,string operardor)
        {
            double aux=0;
            switch (operardor)
            {
                case "+":
                    aux = numero1 + numero2;
                    break;
                case "-":
                    aux = numero1 - numero2;
                    break;
                case "*":
                    aux = numero1 * numero2;
                    break;
                case "/":
                    if (numero2.numero==0)
                    {
                        aux = 0;
                    }
                    else
                    {
                        aux = numero1 / numero2;
                    }
                    break;
            }
            return aux;
        }

        /// <summary>
        /// Metodo que valida que el operador sea un caracter válido, caso contrario retornará “+”. 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
        }
    }
}
