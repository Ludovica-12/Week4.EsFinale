using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.EsFinale.Core.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime DataOrdine { get; set; }
        [DataMember]
        public string CodiceOrdine { get; set; }
        [DataMember]
        public string CodiceProdotto { get; set; }
        [DataMember]
        public decimal Importo { get; set; }

        public Customer Cliente { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
    }
}
