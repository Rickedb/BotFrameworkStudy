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
    public class UpdateHeroesTask :IDisposable
    {
        private readonly IDotaRepository _dotaRepository;
        private bool _dispose = false;

        public UpdateHeroesTask()
        {
            _dotaRepository = new DotaRepository();
        }

        public async Task Run()
        {
            while (!_dispose)
            {
                DotaApp.Heroes = (await _dotaRepository.GetHeroes()).ToList();
                Task.Delay(TimeSpan.FromMinutes(10)).Wait();
            }
        }

        public void Dispose()
        {
            _dispose = true;
        }
    }
}