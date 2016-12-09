using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueTurna;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            MesPrueba, AlDia, Deudor
        }

        #region contructores
        
        /// <summary>
        /// Constructor por defecto de alumno 
        /// </summary>
        public Alumno()
        {}
        /// <summary>
        /// Constructor de alumno 
        /// </summary>
        /// <param name="id"></param>Id del alumno
        /// <param name="nombre"></param>nombre del alumno
        /// <param name="apellido"></param>apellido del alumno
        /// <param name="dni"></param>dni del alumno
        /// <param name="nacionalidad"></param> nacionalidad del alumno
        /// <param name="claseQueToma"></param> clase que toma el alumno
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueTurna = claseQueToma;
        }

        /// <summary>
        /// Constructor de alumno
        /// </summary>
        /// <param name="id"></param>Id del alumno
        /// <param name="nombre"></param>nombre del alumno
        /// <param name="apellido"></param>apellido del alumno
        /// <param name="dni"></param>dni del alumno
        /// <param name="nacionalidad"></param>nacionalidad del alumno
        /// <param name="claseQueToma"></param>clase que toma el alumno
        /// <param name="estadoCuenta"></param>estado de cuenta del alumno
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Gimnasio.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Retorna un string con los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con la clase que turna el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASE DE " + this._claseQueTurna.ToString());
        }

        /// <summary>
        /// Retorna un string con los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region sobrecarga

        /// <summary>
        /// Compara si el almuno toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueTurna == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// Compara si el almuno no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueTurna != clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
