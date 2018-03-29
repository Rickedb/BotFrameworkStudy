using BotApp.App_Start;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(BotApp.Startup))]
namespace BotApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}