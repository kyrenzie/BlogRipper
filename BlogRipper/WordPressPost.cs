using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BlogRipper
{
    [DataContract]
    public class WordPressPost
    {
        [JsonProperty("plan_url")]
        public string PlanUrl { get; set; }

        [JsonProperty("print_url")]
        public string PrintUrl { get; set; }

        [JsonProperty("date")]
        public DateTime DateCreated { get; set; }
 
        [JsonProperty("title")]
        public string Title { get; set; }
 
        [JsonProperty("plan_image")]
        public string PlanImage { get; set; }
 
        [JsonProperty("paragraph1")]
        public string Paragraph1 { get; set; }
        
        [JsonProperty("paragraph2")]
        public string Paragraph2 { get; set; }
        
        [JsonProperty("paragraph3")]
        public string Paragraph3 { get; set; }

        [JsonProperty("paragraph4")]
        public string Paragraph4 { get; set; }
        
        [JsonProperty("date")]
        public DateTime Date { get; set; }

    }
}