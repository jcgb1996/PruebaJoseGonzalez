using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcf.TestPrueba.DistributedServices.Contract.DataContract;

namespace Wcf.TestPrueba.DistributedServices.IContract
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConsultarCansiones
    {
        [OperationContract]
        List<ContratCancionesGeneral> GetDataCanciones();

        [OperationContract]
        List<ContractSonidosGeneral> GetDataSonidos();


        // TODO: agregue aquí sus operaciones de servicio
    }

    
}
