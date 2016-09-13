using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_N_1
{
    public class Numero
    {
        public double numero;
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Contructor recibe double y carga double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor recibe string lo verifica y lo carga
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            setNumero(numero);
            
        }

        /// <summary>
        /// Metodo privado valida que se trate de un double válido caso contrario retornará 0
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double aux;
            if (double.TryParse(numeroString, out aux) == true)
            {
                return aux;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Metodo privado donde se utiliza el metodo validarNumero
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this.numero= validarNumero(numero);
        }  
        
        /// <summary>
        /// Sobrecarga de operador + para la clase numero
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double operator +(Numero A, Numero B)
        {
            double aux;
            aux =A.numero+B.numero;
            return aux;
        }

        /// <summary>
        /// Sobrecarga de operador - para la clase numero
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double operator -(Numero A, Numero B)
        {
            double aux;
            aux = A.numero - B.numero;
            return aux;
        }

        /// <summary>
        /// Sobrecarga de operador * para la clase numero
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double operator *(Numero A, Numero B)
        {
            double aux;
            aux = A.numero * B.numero;
            return aux;
        }

        /// <summary>
        /// Sobrecarga de operador / para la clase numero
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double operator /(Numero A, Numero B)
        {
            double aux;
            aux = A.numero / B.numero;
            return aux;
        }
      
    }
}
