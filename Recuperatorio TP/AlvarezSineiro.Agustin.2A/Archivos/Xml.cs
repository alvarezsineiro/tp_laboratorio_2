using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        /// <summary>
        /// Guarda la informacion en un archivo
        /// </summary>
        /// <param name="archivo"></param> Nombre del archivo
        /// <param name="datos"></param> Informacion a guardar
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
                    writer.Close();
                    flag =true;
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
        public bool leer(string archivo, out T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(reader);
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
