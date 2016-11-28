using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de jornada
        /// </summary>
        /// <param name="clase"></param>clase de la jornada
        /// <param name="instructor"></param> instructor de la jornada
        public Jornada(Gimnasio.EClases clase, Instructor instructor): this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Guarda la jornada en un archivo
        /// </summary>
        /// <param name="jornada"></param>jornada que se va a guardar
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            return text.guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee la jornada de un archivo
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux;

            Texto text = new Texto();
            text.leer("Jornada.txt", out aux);
            return aux;
        }

        /// <summary>
        /// Retorna un string con los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE " + this._clase + " ");
            sb.AppendLine(this._instructor.ToString());

            if (this._alumnos.Count == 0)
            {
                sb.AppendLine("NO HAY ALUMNOS");
            }
            else
            {
                sb.AppendLine("ALUMNOS: ");
                foreach (Alumno item in this._alumnos)
                {
                    sb.Append(item.ToString());
                }
            }
            sb.AppendLine("<---------------------------------------->");
            return sb.ToString();
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Revisa si el alumno esta en la jornada
        /// </summary>
        /// <param name="j"></param>jornada a revisar
        /// <param name="a"></param>alumno a revisar
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {       
            foreach (Alumno item in j._alumnos)
            {
                if (item.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Revisa si el alumno no esta en la jornada
        /// </summary>
        /// <param name="j"></param>jornada a revisar
        /// <param name="a"></param>alumno a revisar
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (!(item.Equals(a)))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Agrega un alumno a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    flag = true;
                    break;
                }
            }
            if (flag==false)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        #endregion
    }
}
