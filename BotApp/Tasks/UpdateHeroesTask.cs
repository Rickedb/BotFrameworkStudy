using BotApp.Helpers;
using BotApp.Models;
using BotApp.Repositories;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BotApp.Tasks
{
    public class UpdateHeroesTask 
    {
        private readonly IDotaRepository _dotaRepository;

        public UpdateHeroesTask()
        {
            _dotaRepository = new DotaRepository();
        }

        public async Task Run()
        {
            DotaApp.Heroes = (await _dotaRepository.GetHeroes()).ToList();
            Thread.Sleep(TimeSpan.FromMinutes(10));
        }
    }
}