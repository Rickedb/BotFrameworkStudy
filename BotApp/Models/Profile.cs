﻿using Newtonsoft.Json;
using System;

namespace BotApp.Models
{
    [Serializable]
    public class Profile
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("personaname")]
        public string Nickname { get; set; }
        [JsonProperty("steamid")]
        public string SteamId { get; set; }
        [JsonProperty("avatarfull")]
        public string AvatarUrl { get; set; }
        //[JsonProperty("last_login")]
        //public DateTime LastLogin { get; set; }
        [JsonProperty("loccountrycode")]
        public string CountryCode { get; set; }
    }
}