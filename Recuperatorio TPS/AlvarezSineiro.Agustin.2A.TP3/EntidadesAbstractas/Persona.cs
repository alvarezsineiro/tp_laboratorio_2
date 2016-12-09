using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        
        #region constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param> Nombre de la persona
        /// <param name="apellido"></param> Apellido de la persona
        /// <param name="nacionalidad"></param> Nacionalidad de la persona
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="dni"></param>DNI de la persona como int
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="dni"></param>DNI de la persona como string
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
            
        }
    #endregion

        #region propiedades
        /// <summary>
        /// Propiedad que retorna y setea el apellido despues de validarlo
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);                
            }
        }

        /// <summary>
        /// Propiedad que retorna y setea el dni despues de validarlo
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad que retorna y setea la Nacionalidad despues de validarlo
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que retorna y setea el nombre despues de validarlo
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propidad que cambia el dni de string a int
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this._nacionalidad, value);                
            }
        }
        #endregion

        #region metodos

        /// <summary>
        /// Retorna un string con los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }


        /// <summary>
        /// Se encarga de validar el Dni
        /// </summary>
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        /// <param name="dato"></param>Dni de la persona
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 90000000)
                    {
                        throw new NacionalidadInvalidaException(dato.ToString());
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 100000000)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Se encarga de validar el Dni 
        /// </summary>
        /// <param name="nacionalidad"></param> Nacionalidad de la persona
        /// <param name="dato"></param> Dni de la persona
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".","");
            return this.ValidarDni(nacionalidad,Int32.Parse(dato));
        }

        /// <summary>
        /// Se encarga de validar el nombre y el apellido
        /// </summary>
        /// <param name="dato"></param> nombre o apellido a validar
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            int i;
            for (i=0;i<dato.Length;i++)
            {
                if ((int)dato[i]<65 || (int)dato[i]>123)
                {
                    return null;
                }
            }
            return dato;
        }
        #endregion
    }
}
