using Newtonsoft.Json;
using System;

namespace BotApp.Models
{
    public class PlayedHeroes
    {
        private long _dateInTicks;

        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
        [JsonProperty("last_played")]
        public DateTime LastPlayed
        {
            get => new DateTime(_dateInTicks);
            set => _dateInTicks = value.Ticks;
        }
        [JsonProperty("games")]
        public int Games { get; set; }
        [JsonProperty("win")]
        public int TotalWins { get; set; }
        [JsonProperty("with_games")]
        public int WithGames { get; set; }
        [JsonProperty("with_win")]
        public int WithWin { get; set; }
        [JsonProperty("against_games")]
        public int AgainstGames { get; set; }
        [JsonProperty("against_win")]
        public int AgainstWin { get; set; }
    }
}