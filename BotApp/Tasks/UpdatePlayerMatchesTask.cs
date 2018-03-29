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
            while (!_dispose)
            {
                Thread.Sleep(TimeSpan.FromMinutes(10));
            }
        }

        public void Dispose()
        {
            _dispose = true;
        }
    }
}