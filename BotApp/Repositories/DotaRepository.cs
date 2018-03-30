using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BotApp.Models;
using Newtonsoft.Json;

namespace BotApp.Repositories
{
    [Serializable]
    public class DotaRepository : IDotaRepository
    {
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            return await Deserialize<List<Hero>>(await Get("https://api.opendota.com/api/heroes"));
        }

        public async Task<Player> GetPlayer(string playerId)
        {
            return await Deserialize<Player>(await Get($"https://api.opendota.com/api/players/{playerId}"));
        }

        public async Task<IEnumerable<RecentMatches>> GetRecentMatches(string playerId)
        {
            return await Deserialize<List<RecentMatches>>(await Get($"https://api.opendota.com/api/players/{playerId}/recentMatches"));
        }

        public async Task<IEnumerable<PlayedHeroes>> GetPlayedHeroes(string playerId)
        {
            return await Deserialize<List<PlayedHeroes>>(await Get($"https://api.opendota.com/api/players/{playerId}/heroes"));
        }

        public void Dispose()
        {

        }

        private async Task<HttpResponseMessage> Get(string url)
        {
            using (var request = new HttpClient())
            {
                return await request.GetAsync(url);
            }
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
                return default(T);

            var json = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}