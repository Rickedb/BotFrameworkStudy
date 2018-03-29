using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApp.Helpers
{
    public class DotaEndpointsHelper
    {
        public const string GetHeroes = "";
        public static string GetPlayer(string id) => $"https://api.opendota.com/api/players/{id}";
    }
}