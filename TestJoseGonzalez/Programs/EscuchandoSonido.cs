using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJoseGonzalez.Intermediario;

namespace TestJoseGonzalez.Programs
{
    public class EscuchandoSonido
    {
        Consumo consu = Consumo.CrearInstancia();
        #region incio Consola
        public void Iniciar()
        {

            string RecibirSonido = string.Empty;
            string TipoAnimal = string.Empty;
            string Musica = string.Empty;
            EscuchandoSonido Sonido = new EscuchandoSonido();
            Console.WriteLine("Ingrese un sonido: ");
            RecibirSonido = Console.ReadLine();
            var SonidoAsociado = Sonido.AsociarSonido(RecibirSonido, ref TipoAnimal, ref Musica);
            Console.WriteLine("\n");
            Console.WriteLine(SonidoAsociado.Split('|')[0] != "ok" ? SonidoAsociado : "Animal: " + SonidoAsociado.Split('|')[1]);
            Console.WriteLine("Musica: " + Musica);
            Console.WriteLine("\n");
        }

        #endregion

        public string AsociarSonido(string SonidoIngresado, ref string TipoAnimal, ref string Musica)
        {
            string Mensaje = string.Empty;
            //string _TipoAnimal = string.Empty;
            try
            {
                var DatosSonido = consu.ConsultarSonido();
                Mensaje = !ExisteSonido(DatosSonido.Select(x => x).ToList(), SonidoIngresado, ref TipoAnimal) ? "El sonido no coincide con ninguno de los animales que escucho el explorador" : "ok" + "|" + TipoAnimal;
                Musica = ConsultarMusicas(SonidoIngresado);
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message + "";
            }
            return Mensaje;
        }

        #region Validar Sonidos y musica
        private bool ExisteSonido(List<ConsultaGeneralServices.ContractSonidosGeneral> DatosSonido, string SonidoIngresado, ref string TipoAnimal)
        {
            bool ExisteSonido = false;
            var DatosRana = DatosSonido.Select(x => x._Rana.Select(y => y)).DefaultIfEmpty(null).FirstOrDefault().ToList();
            var DatosLibelula = DatosSonido.Select(x => x._Libelula.Select(y => y)).DefaultIfEmpty(null).FirstOrDefault().ToList();
            var DatosGrillo = DatosSonido.Select(x => x._Grillo.Select(y => y)).DefaultIfEmpty(null).FirstOrDefault().ToList();
            foreach (var a in DatosRana)
            {

                var SonidoRana = a.Sonido.Split('|');
                for (int i = 0; i < SonidoRana.Count(); i++)
                {
                    if (ExisteSonido) break;
                    ExisteSonido = SonidoRana[i].ToLower() == SonidoIngresado.ToLower() ? true : false;
                }
                TipoAnimal = ExisteSonido ? a.NombreAnimal : string.Empty;
                if (ExisteSonido) break;
            }
            foreach (var a in DatosLibelula)
            {
                if (ExisteSonido) break;
                var SonidoLibelula = a.Sonido.Split('|');
                for (int i = 0; i < SonidoLibelula.Count(); i++)
                {
                    if (ExisteSonido) break;
                    ExisteSonido = SonidoLibelula[i].ToLower() == SonidoIngresado.ToLower() ? true : false;
                }
                TipoAnimal = ExisteSonido ? a.NombreAnimal : string.Empty;
            }
            foreach (var a in DatosGrillo)
            {
                if (ExisteSonido) break;
                var SonidoGrillo = a.Sonido.Split('|');
                for (int i = 0; i < SonidoGrillo.Count(); i++)
                {
                    if (ExisteSonido) break;
                    ExisteSonido = SonidoGrillo[i].ToLower() == SonidoIngresado.ToLower() ? true : false;
                }
                TipoAnimal = ExisteSonido ? a.NombreAnimal : string.Empty;
            }


            return ExisteSonido;
        }
        private string ValidarMusica(List<ConsultaGeneralServices.ContratCancionesGeneral> DatosSonido, string SonidoIngresado, string TipoSonido)
        {
            string musica = string.Empty;
            var _Musica = DatosSonido.Select(x => x.musica).ToList();
            switch (TipoSonido)
            {
                case "brr":
                    {
                        var Musicas = _Musica[0].Split('|');
                        for (int i = 0; i < Musicas.Count(); i++)
                        {
                            if (Musicas[i].ToLower() == TipoSonido.ToLower())
                            {
                                musica = i == 0 ? string.Empty : _Musica[i];
                                musica = musica + "" + _Musica[i] + "";
                                break;
                            }


                        }
                    }
                    break;
                case "birip":
                    {
                        var Musicas = _Musica[1].Split('|');
                        Musicas[0] = string.Empty;
                        Musicas[1] = string.Empty;
                        for (int i = 0; i < Musicas.Count(); i++)
                        {
                            if (!string.IsNullOrEmpty(Musicas[i]))
                            {
                                musica = musica + "," + Musicas[i] + "";
                                //break;
                            }


                        }
                    }

                    break;
                case "plop":
                    {
                        var Musicas = _Musica[1].Split('|');
                        Musicas[0] = string.Empty;
                        Musicas[1] = string.Empty;
                        for (int i = 0; i < Musicas.Count(); i++)
                        {
                            if (!string.IsNullOrEmpty(Musicas[i]))
                            {
                                musica = musica + "," + Musicas[i] + "";
                                //break;
                            }


                        }
                    }

                    break;
                case "croac":
                    musica = "-Silencio-";
                    break;
                case "brrah":
                    musica = "-Silencio-";
                    break;
            }

            return musica;
        }

        #endregion

        #region Reproducir Musica
        public string ConsultarMusicas(string SonidoIngresado)
        {
            string Musica = string.Empty;
            try
            {
                var DatosSonido = consu.ConsultarMusicas();
                switch (SonidoIngresado.ToLower())
                {
                    case "brr":
                        Musica = ValidarMusica(DatosSonido, SonidoIngresado, "brr");
                        break;
                    case "birip":
                        Musica = ValidarMusica(DatosSonido, SonidoIngresado, "birip");
                        break;
                    case "plop":
                        Musica = ValidarMusica(DatosSonido, SonidoIngresado, "plop");
                        break;
                    case "croac":
                        Musica = ValidarMusica(DatosSonido, SonidoIngresado, "croac");
                        break;
                    case "brrah":
                        Musica = ValidarMusica(DatosSonido, SonidoIngresado, "brrah");
                        break;

                }
            }
            catch (Exception ex)
            {
                Musica = ex.Message;
            }

            return Musica;
        }
        #endregion



    }
}
