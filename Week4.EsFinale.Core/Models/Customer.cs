using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Week4.EsFinale.Core.Models
{
    [DataContract]
    public class Customer
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cognome { get; set; }

        public List<Order> Ordine { get; set; } = new List<Order>();

    }
}
