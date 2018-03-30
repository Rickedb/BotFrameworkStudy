using BotApp.Models;
using BotApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Tasks
{
    public class UpdatePlayerMatchesTask
    {
        private readonly IDotaRepository _dotaRepository;
        private bool _dispose;

        public UpdatePlayerMatchesTask()
        {
            _dotaRepository = new DotaRepository();
        }

        public async Task Run()
        {
            Dictionary<string, long> lastMatchIds = new Dictionary<string, long>();
            while (!_dispose)
            {
                foreach (var id in DotaApp.PlayerIds)
                {
                    Player player = await GetPlayer(id);
                    var recentMatches = (await _dotaRepository.GetRecentMatches(id));
                    long lastId = recentMatches.Max(x => x.MatchId);
                    if (lastMatchIds.ContainsKey(id))
                    {
                        var selectedMatches = recentMatches.Where(x => x.MatchId > lastMatchIds[id]).ToList();
                        foreach(var match in selectedMatches)
                        {
                            match.Hero = GetHero(match.HeroId);
                            match.Player = player;
                        }
                        QueueRepository.Instance.Add(selectedMatches);
                        lastMatchIds[id] = lastId;
                    }
                    else
                    {
                        var selectedMatches = recentMatches.ToList();
                        foreach (var match in selectedMatches)
                        {
                            match.Hero = GetHero(match.HeroId);
                            match.Player = player;
                        }
                        QueueRepository.Instance.Add(selectedMatches);
                        lastMatchIds.Add(id, lastId);
                    }

                }
                Task.Delay(TimeSpan.FromSeconds(30)).Wait();
            }
        }

        public void Dispose()
        {
            _dispose = true;
        }

        private async Task<Player> GetPlayer(string id) => await _dotaRepository.GetPlayer(id);

        private Hero GetHero(int id) => DotaApp.Heroes.FirstOrDefault(x => x.Id == id);
    }
}