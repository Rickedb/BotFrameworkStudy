using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BotApp.Models
{
    [Serializable]
    public class Hero
    {
        private string _attribute;

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("localized_name")]
        public string Name { get; set; }
        [JsonProperty("primary_attr")]
        public string PrimaryAttribute
        {
            get
            {
                switch(_attribute)
                {
                    case "str": return "Strength";
                    case "agi": return "Agility";
                    case "int": return "Intelligence";
                    default: return "Unknown";
                }
            }
            set => _attribute = value;
        }
        [JsonProperty("attack_type")]
        public string AttackType { get; set; }
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
        [JsonProperty("legs")]
        public int Legs { get; set; }
    }
}