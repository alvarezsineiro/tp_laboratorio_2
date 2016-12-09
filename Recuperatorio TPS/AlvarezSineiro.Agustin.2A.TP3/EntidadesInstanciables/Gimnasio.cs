using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public enum EClases
        {
            CrossFit, Pilates, Natacion,Yoga
        }

        #region constructor

        /// <summary>
        /// Constructor por defecto de gimnasio
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region metodos

        /// <summary>
        /// Guarda los datos del gimnasio en un archivo
        /// </summary>
        /// <param name="gim"></param>gimnasio que se desea guardar los datos
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();
            xml.guardar("Gimnasio.xml", gim);
            return true;
        }

        /// <summary>
        /// Lee los datos de un gimnasio de un archivo
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            Gimnasio aux = null;
            Xml<Gimnasio> deserializador = new Xml<Gimnasio>();
            deserializador.leer("Gimnasio.xml", out aux);
            return aux;
        }

        /// <summary>
        /// Retorna un string con los datos del gimnasio
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in gim._jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con los datos del gimnasio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion
        
        #region sobrecarga

        /// <summary>
        /// Agrega un alumno al gimnasio
        /// </summary>
        /// <param name="gim"></param>gimnasio que se agrega alumno
        /// <param name="alum"></param>alumno a agregar
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Alumno alum)
        {
            bool flag = true;
            foreach (Alumno item in gim._alumnos)
            {
                if (item == alum)
                {
                    flag = false;
                    break;
                }
            }
            if (flag==true)
            {
                gim._alumnos.Add(alum);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return gim;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio
        /// </summary>
        /// <param name="gim"></param>gimnasio que se agrega gimnasio
        /// <param name="ins"></param>gimnasio a agregar
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Instructor ins)
        {
            bool flag = true;
            foreach (Instructor item in gim._instructores)
            {
                if (item == ins)
                {
                    flag = false;
                    break;
                }
            }
            if (flag==true)
            {
                gim._instructores.Add(ins);
            }
            return gim;
        }

        /// <summary>
        /// Revisa si el alumno ya se encuentra en el gimnasio
        /// </summary>
        /// <param name="gim"></param>gimnasio que se esta revisando
        /// <param name="alum"></param>alumno que se esta revisando
        /// <returns></returns>
        public static bool operator ==(Gimnasio gim, Alumno alum)
        {
            foreach (Alumno item in gim._alumnos)
            {
                if (item.DNI == alum.DNI)
                {
                    return true;                    
                }
            }
            return false;
        }

        /// <summary>
        /// Revisa si el alumno no se encuentra en el gimnasio
        /// </summary>
        /// <param name="gim"></param>gimnasio que se esta revisando
        /// <param name="alum"></param>alumno que se esta revisando
        /// <returns></returns>
        public static bool operator !=(Gimnasio gim, Alumno alum)
        {
            foreach (Alumno item in gim._alumnos)
            {
                if (item.DNI != alum.DNI)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Agrega una clase al gimnasio
        /// </summary>
        /// <param name="gim"></param>gimnasio que se agrega clase
        /// <param name="clase"></param>clase que se agrega
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Gimnasio.EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (gim == clase));
            foreach (Alumno item in gim._alumnos)
            {
                if (item == clase)
                {
                    nuevaJornada = nuevaJornada + item;
                }
            }
            gim._jornada.Add(nuevaJornada);
            return gim;

        }

        /// <summary>
        /// Revisa si hay un instructor para dar clase
        /// </summary>
        /// <param name="gim"></param>gimnasio que se revisa
        /// <param name="clase"></param>clase que se va dictar
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio gim, Gimnasio.EClases clase)
        {
            int i;
            for (i=0; i<gim._instructores.Count; i++)
            {
                if (gim._instructores[i] == clase)
                {
                    return gim._instructores[i];
                }
            }           
            throw new SinInstructorException();
        }

        /// <summary>
        /// Revisa si no hay un instructor para dar clase
        /// </summary>
        /// <param name="gim"></param>gimnasio que se revisa
        /// <param name="clase"></param>clase que se va dictar
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio gim, Gimnasio.EClases clase)
        {
            int i;
            for (i = 0; i < gim._instructores.Count; i++)
            {
                if (gim._instructores[i] != clase)
                {
                    return gim._instructores[i];
                }
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Revisa si hay un instructor 
        /// </summary>
        /// <param name="gim"></param>gimnasio que se revisa
        /// <param name="ins"></param>instructor que se revisa
        /// <returns></returns>
        public static bool operator ==(Gimnasio gim, Instructor ins)
        {            
            foreach (Instructor item in gim._instructores)
            {
                if (item==ins)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Revisa si hay un instructor 
        /// </summary>
        /// <param name="gim"></param>gimnasio que se revisa
        /// <param name="ins"></param>instructor que se revisa
        /// <returns></returns>
        public static bool operator !=(Gimnasio gim, Instructor ins)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item != ins)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Indice de la lista de Jornadas
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
              return this._jornada[i];               
            }
        }
        #endregion
    }
}
