using BotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApp.Repositories
{
    public class QueueRepository
    {
        private static QueueRepository _instance;
        private static List<RecentMatches> NewMatches;

        public static QueueRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QueueRepository();

                return _instance;
            }
        }

        private QueueRepository()
        {
            NewMatches = new List<RecentMatches>();
        }

        public void Add(RecentMatches match) => NewMatches.Add(match);

        public void Add(IEnumerable<RecentMatches> matches) => NewMatches.AddRange(matches);

        public List<RecentMatches> GetQueueList()
        {
            var queue = new List<RecentMatches>(NewMatches);
            NewMatches.Clear();
            return queue;
        }
    }
}