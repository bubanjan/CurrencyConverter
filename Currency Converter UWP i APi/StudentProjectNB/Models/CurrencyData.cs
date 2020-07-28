using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProjectNB.Models
{

   

    public class Rootobject
    {
        [JsonProperty("amount")]
        public double amount { get; set; }
        [JsonProperty("base")]
        public string basec { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("rates")]
        //  public Rates rates { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }

    
}
