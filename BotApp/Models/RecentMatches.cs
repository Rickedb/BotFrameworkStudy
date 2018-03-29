using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApp.Models
{
    [Serializable]
    public class RecentMatches
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }
        public int PlayerSlot { get; set; }
        public bool RadiantWin { get; set; }
        [JsonIgnore]
        public string Winner { get => RadiantWin ? "Radiant" : "Dire"; }
        public long Duration { get; set; }
        [JsonIgnore]
        public TimeSpan DurationTime { get => TimeSpan.FromMilliseconds(Duration); }
        public int GameMode { get; set; }
        public int LobbyType { get; set; }
        public int HeroId { get; set; }

        [JsonIgnore]
        public virtual Hero Hero { get; set; }
    }
}