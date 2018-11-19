using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestJoseGonzalez.ConsultaGeneralServices;

namespace TestJoseGonzalez.Intermediario
{
    public class Consumo
    {
        #region Instancia de la clase
        private static Consumo consumo;
        private Consumo()
        {
        }
        public static Consumo CrearInstancia()
        {
            if (consumo == null)
            {
                consumo = new Consumo();
            }
            return consumo;


        }

        #endregion

        public List<ContractSonidosGeneral> ConsultarSonido()
        {
            ConsultarCansionesClient Consulta = null;
            List<ContractSonidosGeneral> Datos = null;
            try
            {

                Consulta = new ConsultarCansionesClient();
                Datos = new List<ContractSonidosGeneral>();
                Datos = Consulta.GetDataSonidos().ToList();
            }
            catch (Exception)
            {
                Consulta.Abort();
            }
            finally
            {
                if (Consulta != null && Consulta.State == CommunicationState.Opened)
                {
                    Consulta.Close();
                }
            }
            return Datos;
        }


        public List<ContratCancionesGeneral> ConsultarMusicas()
        {
            ConsultarCansionesClient Consulta = null;
            List<ContratCancionesGeneral> Datos = null;
            try
            {

                Consulta = new ConsultarCansionesClient();
                Datos = new List<ContratCancionesGeneral>();
                Datos = Consulta.GetDataCanciones().ToList();
            }
            catch (Exception)
            {
                Consulta.Abort();
            }
            finally
            {
                if (Consulta != null && Consulta.State == CommunicationState.Opened)
                {
                    Consulta.Close();
                }
            }
            return Datos;
        }
    }
}
