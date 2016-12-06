using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda la informacion en un archivo
        /// </summary>
        /// <param name="archivo"></param> Nombre del archivo
        /// <param name="datos"></param> Informacion a guardar
        /// <returns></returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Toma la informacion de un archivo
        /// </summary>
        /// <param name="archivo"></param>Nombre del archivo
        /// <param name="datos"></param>Informacion a leer
        /// <returns></returns>
        bool leer(string archivo, out T datos);
    }
}
