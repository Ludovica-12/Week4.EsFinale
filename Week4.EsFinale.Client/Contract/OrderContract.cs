using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.EsFinale.Client.Contract
{
    public class OrderContract
    {
        public int OrderId { get; set; }

        public DateTime DataOrdine { get; set; }

        public string CodiceOrdine { get; set; }

        public string CodiceProdotto { get; set; }

        public decimal Importo { get; set; }
    }
}
