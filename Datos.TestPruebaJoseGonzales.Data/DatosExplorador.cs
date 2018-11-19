using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.TestPruebaJoseGonzales.Data
{
    public class DatosExplorador
    {
        public List<General> ConsultarSonidos()
        {
            Sonidos _Sonido = new Sonidos();
            return _Sonido.ConsultarSonidos();
        }

        public List<Musicas> ConsultarCanciones()
        {
            Canciones _Cancion = new Canciones();
           return  _Cancion.ConsultarCanciones();
        }
    }
}
