using BotApp.Tasks;
using Hangfire;
using System.Threading.Tasks;

namespace BotApp.App_Start
{
    public static class HangfireTasksConfig
    {
        public static void RegisterRecurringTasks()
        {
            BackgroundJob.Enqueue(() => new UpdateHeroesTask().Run());
        }
    }
}