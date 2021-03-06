﻿using Newtonsoft.Json;
using System;

namespace BotApp.Models
{
    [Serializable]
    public class Player
    {
        [JsonProperty("tracked_until")]
        public int TrackedUntil { get; set; }
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
        [JsonProperty("competitive_rank")]
        public string TeamRank { get; set; }
        [JsonProperty("solo_competitive_rank")]
        public string SoloRank { get; set; }
        [JsonProperty("leaderboard_rank")]
        public int LeaderboardRank { get; set; }
        [JsonProperty("rank_tier")]
        public int RankTier { get; set; }
        [JsonProperty("mmr_estimate")]
        public EstimatedMmr EstimatedMmr { get; set; }
    }
}