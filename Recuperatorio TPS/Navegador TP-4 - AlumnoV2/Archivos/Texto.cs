using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _ruta;

        public Texto(string archivo)
        {
            this._ruta = archivo;
        }

        /// <summary>
        /// Guarda los datos indicados en un archivo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter writer = new StreamWriter (this._ruta,true))
                {
                    writer.WriteLine(datos);
                    writer.Close();
                    flag = true;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return flag;
            
        }

        /// <summary>
        /// Lee los datos indicados de un archivo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            bool flag = false;
            datos = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(this._ruta))
                {
                    while (reader.EndOfStream==false)
                    {
                        datos.Add(reader.ReadLine());
                        flag = true;
                    }                    
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return flag;
        }
    }
}
