using Newtonsoft.Json;

namespace BotApp.Models
{
    public class EstimatedMmr
    {
        [JsonProperty("estimate")]
        public int Estimated { get; set; }
    }
}