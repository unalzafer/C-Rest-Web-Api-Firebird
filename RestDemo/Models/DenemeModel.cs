using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestDemo.Models
{
    [DataContract]
    public class DenemeModel
    {
        [DataMember(Name = "Blkodu")]
        public string Blkodu { get; set; }
        [DataMember(Name="StokKodu")]
        public string StokKodu { get; set; }
        [DataMember(Name = "StokAdı")]
        public string StokAdı{ get; set; }
    }
}