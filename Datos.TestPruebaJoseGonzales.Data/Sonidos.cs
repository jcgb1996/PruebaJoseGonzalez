using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.TestPruebaJoseGonzales.Data
{
    public class Sonidos
    {
        
        public List<General> ConsultarSonidos()
        {
            List<Rana> ranaSun = new List<Rana>();
            List<Libelula> libelulaSun = new List<Libelula>();
            List<Grillo> grilloSun = new List<Grillo>();
            List<General> DatosSonidos = new List<General>();
            try
            {
                ranaSun.Add(new Rana("brr|birip|brrah|croac","Rana"));
                libelulaSun.Add(new Libelula("fiu|plop|pep", "Libelula"));
                grilloSun.Add(new Grillo("cric-cric|trri-trri|bri-bri", "Grillo"));



                DatosSonidos.Add(new General()
                {
                    _Rana = ranaSun,
                    _Libelula = libelulaSun,
                    _Grillo = grilloSun,
                });
            }
            catch (Exception)
            {
                DatosSonidos = null;
            }           
            

            return DatosSonidos;

        }

    }

    #region Clases 

    public class General
    {
        public List<Rana> _Rana;
        public List<Libelula> _Libelula;
        public List<Grillo> _Grillo;
        
    }
    public class Rana
    {
        public string Sonido { get; set; }
        public string NombreAnimal { get; set; }
        public Rana(string _sonido, string _NombreAnimal)
        {
            this.Sonido = _sonido;
            this.NombreAnimal = _NombreAnimal;
        }
    }
    public class Libelula : Rana
    {
        public Libelula(string _sonido, string _NombreAnimal) : base(_sonido, _NombreAnimal)
        {
            this.Sonido = _sonido;
            this.NombreAnimal = _NombreAnimal;
        }
    }
    public class Grillo : Rana
    {
        public Grillo(string _sonido, string _NombreAnimal) : base(_sonido, _NombreAnimal)
        {
            this.Sonido = _sonido;
            this.NombreAnimal = _NombreAnimal;
        }
    }
    #endregion

}
