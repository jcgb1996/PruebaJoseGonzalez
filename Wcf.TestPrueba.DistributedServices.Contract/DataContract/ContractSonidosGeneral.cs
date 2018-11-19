using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Wcf.TestPrueba.DistributedServices.Contract.Constante;
using Wcf.TestPrueba.DistributedServices.Contract.Entidades;

namespace Wcf.TestPrueba.DistributedServices.Contract.DataContract
{
    [DataContract(Namespace = Contracts.Namespace)]
    public class ContractSonidosGeneral
    {
        #region Constants and Fields
        private const int Version1 = 1;
        #endregion

        #region IExtensibleDataObject Members
        public virtual ExtensionDataObject ExtensionData { get; set; }
        #endregion


        [DataMember(IsRequired = true, Order = Version1)]
        public List<EntidadesRana> _Rana { get; set; }
        [DataMember(IsRequired = true, Order = Version1)]
        public List<EntidadesGrillo> _Grillo { get; set; }
        [DataMember(IsRequired = true, Order = Version1)]
        public List<EntidadesLibelula> _Libelula { get; set; }

    }
}
