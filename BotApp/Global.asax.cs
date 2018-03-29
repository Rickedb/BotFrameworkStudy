using BotApp.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BotApp
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DotaApp.RunningTasks = new List<Task>()
            {
                Task.Run(new UpdateHeroesTask().Run)
                Task.Run(new UpdatePlayerMatchesTask().Run)
            };
        }

        protected void Application_End()
        {
            DotaApp.RunningTasks.ForEach(x => x.Dispose());
        }
    }
}
