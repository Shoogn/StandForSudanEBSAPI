using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandForSudanEBSAPI.Models
{
    public class StandForSudan
    {
        public StandForSudan() { }
        [JsonProperty("NumberOfTransaction")]
        public long No_OfTransaction { get; set; }
        public double TotalAmount { get; set; }
    }
}
