using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Delegado del evento descargando
        /// </summary>
        /// <param name="Progreso"></param>
        public delegate void EventDescargando(int Progreso);

        /// <summary>
        /// Evento del tipo del delegado
        /// </summary>
        public event EventDescargando Descargando;

        /// <summary>
        /// Genera un evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Descargando(e.ProgressPercentage);
        }

        /// <summary>
        ///  Delegado del evento descargacompleta
        /// </summary>
        /// <param name="Terminado"></param>
        public delegate void EventCompletado(string Terminado);
        
        /// <summary>
        /// Evento del tipo del delegado
        /// </summary>
        public event EventCompletado DescargaCompleta;

        /// <summary>
        /// Genera un evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.DescargaCompleta(e.Result);
        }
    }
}
