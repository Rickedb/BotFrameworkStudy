using BotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApp
{
    public static class DotaApp
    {
        public static List<Hero> Heroes { get; set; }
        public static List<string> PlayerIds { get; set; } 
        public static List<Task> RunningTasks { get; set; }
    }
}