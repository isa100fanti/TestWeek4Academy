using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.EsercitazioneWebServices.Core.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public string OrderCode { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        public Client Client { get; set; } //nav property

    }
}
