using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        /// <summary>
        /// Guarda la informacion en un archivo
        /// </summary>
        /// <param name="archivo"></param> Nombre del archivo
        /// <param name="datos"></param> Informacion a guardar
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, false))
                {
                    writer.Write(datos);
                    writer.Close();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }

        /// <summary>
        /// Toma la informacion de un archivo
        /// </summary>
        /// <param name="archivo"></param>Nombre del archivo
        /// <param name="datos"></param>Informacion a leer
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            bool flag = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadToEnd();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }
    }
}
