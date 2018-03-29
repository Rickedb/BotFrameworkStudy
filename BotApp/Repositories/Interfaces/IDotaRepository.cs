using BotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Repositories
{
    public interface IDotaRepository : IDisposable
    {
        Task<IEnumerable<Hero>> GetHeroes();
        Task<Player> GetPlayer(string playerId);
        Task<IEnumerable<RecentMatches>> GetRecentMatches(string playerId);
        Task<IEnumerable<PlayedHeroes>> GetPlayedHeroes(string playerId);
    }
}