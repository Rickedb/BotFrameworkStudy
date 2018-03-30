using Newtonsoft.Json;
using System;

namespace BotApp.Models
{
    [Serializable]
    public class RecentMatches
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }
        [JsonProperty("player_slot")]
        public int PlayerSlot { get; set; }
        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }
        [JsonIgnore]
        public string Winner { get => RadiantWin ? "Radiant" : "Dire"; }
        [JsonProperty("duration")]
        public long Duration { get; set; }
        [JsonIgnore]
        public TimeSpan DurationTime { get => TimeSpan.FromSeconds(Duration); }
        [JsonProperty("game_mode")]
        public int GameMode { get; set; }
        [JsonProperty("lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
        [JsonProperty("start_time")]
        public int StartTime { get; set; }
        [JsonIgnore]
        public TimeSpan StartedTime { get => TimeSpan.FromMilliseconds(StartTime); }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("kills")]
        public int Kills { get; set; }
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        [JsonProperty("assists")]
        public int Assists { get; set; }
        [JsonProperty("skill")]
        public int Skill { get; set; }
        [JsonProperty("lane")]
        public int Lane { get; set; }
        [JsonProperty("lane_role")]
        public int LaneRole { get; set; }
        [JsonProperty("party_size")]
        public int PartySize { get; set; }
        [JsonProperty("xp_per_min")]
        public int ExpPerMinute { get; set; }
        [JsonProperty("gold_per_min")]
        public int GoldPerMinute { get; set; }
        [JsonProperty("hero_damage")]
        public int HeroDamage { get; set; }
        [JsonProperty("tower_damage")]
        public int TowerDamage { get; set; }
        [JsonProperty("hero_healing")]
        public int HeroHealing { get; set; }
        [JsonProperty("last_hits")]
        public int LastHits { get; set; }


        [JsonIgnore]
        public virtual Player Player{ get; set; }
        [JsonIgnore]
        public virtual Hero Hero { get; set; }
    }
}