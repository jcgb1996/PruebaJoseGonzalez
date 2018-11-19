using Datos.TestPruebaJoseGonzales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcf.TestPrueba.DistributedServices.Contract;
using Wcf.TestPrueba.DistributedServices.Contract.DataContract;
using Wcf.TestPrueba.DistributedServices.Contract.Entidades;
using Wcf.TestPrueba.DistributedServices.IContract;

namespace Wcf.TestPrueba.DistributedServices.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ConsultarCanciones : IConsultarCansiones
    {
        public List<ContratCancionesGeneral> GetDataCanciones()
        {
            DatosExplorador _Cancion;
            List<ContratCancionesGeneral> datosCancionesContract;
            try
            {
                _Cancion = new DatosExplorador();
                datosCancionesContract = new List<ContratCancionesGeneral>();
                var DatosCanciones = _Cancion.ConsultarCanciones();
                datosCancionesContract = DatosCanciones.Select(x => new ContratCancionesGeneral() { musica = x.musica }).ToList();
            }
            catch (Exception)
            {
                datosCancionesContract = new List<ContratCancionesGeneral>();
            }


            return datosCancionesContract;

        }

        public List<ContractSonidosGeneral> GetDataSonidos()
        {
            DatosExplorador _Cancion;
            List<ContractSonidosGeneral> DatosSonidos;
            try
            {
                _Cancion = new DatosExplorador();
                DatosSonidos = new List<ContractSonidosGeneral>();
                //List<EntidadesRana> LisRana = new List<EntidadesRana>();
                //List<EntidadesLibelula> LisLibelula = new List<EntidadesLibelula>();
                //List<EntidadesGrillo> LisGrillo = new List<EntidadesGrillo>();

                var Datos = _Cancion.ConsultarSonidos();
                //var DatosRana = Datos.Select(x => x._Rana.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault()).DefaultIfEmpty(null).FirstOrDefault();
                var DatosRana = Datos.Select(x =>
                new EntidadesRana()
                {
                    Sonido = x._Rana.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault(),
                    NombreAnimal = x._Rana.Select(y => y.NombreAnimal).DefaultIfEmpty(null).FirstOrDefault()
                }).ToList();


                // LisRana.Add(new EntidadesRana { Sonido = DatosRana, NombreAnimal =  });
                //var DatosLibelula = Datos.Select(x => x._Libelula.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault()).DefaultIfEmpty(null).FirstOrDefault();
                var LisLibelula = Datos.Select(x =>
                new EntidadesLibelula()
                {
                    Sonido = x._Libelula.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault(),
                    NombreAnimal = x._Libelula.Select(y => y.NombreAnimal).DefaultIfEmpty(null).FirstOrDefault(),

                }
                ).ToList();
                //var DatosGrillo = Datos.Select(x => x._Grillo.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault()).DefaultIfEmpty(null).FirstOrDefault();
                //LisGrillo.Add(new EntidadesGrillo { Sonido = DatosGrillo });
                var LisGrillo = Datos.Select(x =>
                new EntidadesGrillo()
                {
                    Sonido = x._Grillo.Select(y => y.Sonido).DefaultIfEmpty(null).FirstOrDefault(),
                    NombreAnimal = x._Grillo.Select(y => y.NombreAnimal).DefaultIfEmpty(null).FirstOrDefault(),

                }
                ).ToList();

                DatosSonidos.Add(new ContractSonidosGeneral
                {
                    _Rana = DatosRana,
                    _Grillo = LisGrillo,
                    _Libelula = LisLibelula,
                });



            }
            catch (Exception)
            {
                DatosSonidos = null;
            }

            return DatosSonidos;
        }
    }
}
