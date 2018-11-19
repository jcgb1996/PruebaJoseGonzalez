using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.TestPruebaJoseGonzales.Data
{
    public class Canciones
    {
        public List<Musicas> ConsultarCanciones()
        {
            List<Musicas> _Musicas = new List<Musicas>();
            try
            {
                _Musicas.Add(new Musicas() { musica = "brr|fiu|cric-cric|brrah" });
                _Musicas.Add(new Musicas() { musica = "pep|birip|trri-trri|croac" });
                _Musicas.Add(new Musicas() { musica = "bri-bri|plop|cric-cric|brrah" });

            }
            catch (Exception)
            {
                _Musicas = null;
            }
            
            return _Musicas;
        }
    }

    #region  ClaseMuscas
    public class Musicas
    {
        public string musica { get; set; }
    }

    #endregion
}
