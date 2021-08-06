using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week4.EsercitazioneWebServices.Core.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string ClientCode { get; set; }
        public List<Order> Orders { get; set; }

    }
}
