using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;


        #region constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor de instructor
        /// </summary>
        /// <param name="id"></param>id del instructor
        /// <param name="nombre"></param>nombre del instructor
        /// <param name="apellido"></param>apellido del instructor
        /// <param name="dni"></param>dni del instructor
        /// <param name="nacionalidad"></param>nacionalidad del instructor
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion

        #region metodos

        /// <summary>
        /// Genera las clases random del instructor
        /// </summary>
        private void _randomClases()
        {
            int aux = _random.Next(1, 4);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(1, 4));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(1, 4));
        }

        /// <summary>
        /// Retorna un string con los datos del instructor
        /// </summary>
        /// <returns></returns>
        protected string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();

        }

        /// <summary>
        /// Retorna un string con las clases del instructor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con los datos del instructor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Comprueba si el instructor da una clase
        /// </summary>
        /// <param name="ins"></param>instructor a revisar
        /// <param name="clase"></param>clase que se debe dar
        /// <returns></returns>
        public static bool operator ==(Instructor ins, Gimnasio.EClases clase)
        {            
            foreach (Gimnasio.EClases item in ins._clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Comprueba si el instructor no da una clase
        /// </summary>
        /// <param name="ins"></param>instructor a revisar
        /// <param name="clase"></param>clase que se debe dar
        /// <returns></returns>
        public static bool operator !=(Instructor ins, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in ins._clasesDelDia)
            {
                if (item != clase)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
