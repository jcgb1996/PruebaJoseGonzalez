using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Wcf.TestPrueba.DistributedServices.Contract.Constante;

namespace Wcf.TestPrueba.DistributedServices.Contract.DataContract
{
    [DataContract(Namespace = Contracts.Namespace)]
    public class ContratCancionesGeneral
    {
        #region Constants and Fields
        private const int Version1 = 1;
        #endregion

        #region IExtensibleDataObject Members
        public virtual ExtensionDataObject ExtensionData { get; set; }
        #endregion


        [DataMember(IsRequired = true, Order = Version1)]
        public string musica { get; set; }
     
    }
}
