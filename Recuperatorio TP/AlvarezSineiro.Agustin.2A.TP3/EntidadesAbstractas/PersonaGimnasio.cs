using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {
        private int _identificador;


        #region contructores
        /// <summary>
        /// Constructor por defecto de personagimnasio
        /// </summary>
        public PersonaGimnasio()
        { }

        /// <summary>
        /// Constructor de personagimnasio
        /// </summary>
        /// <param name="id"></param> ID de la persona
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="dni"></param>Dni de la persona
        /// <param name="nacionalidad"></param> Nacionalidad de la persona
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Compara si un objeto es de clase personagimnasio
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  Retorna un string con los datos de la personagimnasio
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador);
            return sb.ToString();
        }

        protected virtual string ParticiparEnClase()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region sobrecarga

        /// <summary>
        /// Compara si dos personagimnasio son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1,PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara si dos personagimnasio son distintas
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.DNI != pg2.DNI || pg1._identificador != pg2._identificador)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
