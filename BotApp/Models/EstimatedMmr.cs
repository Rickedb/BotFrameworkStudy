using Newtonsoft.Json;
using System;

namespace BotApp.Models
{
    [Serializable]
    public class EstimatedMmr
    {
        [JsonProperty("estimate")]
        public int Estimated { get; set; }
    }
}