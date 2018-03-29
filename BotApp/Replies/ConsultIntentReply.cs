using BotApp.Replies.Entities;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BotApp.Replies
{
    [Serializable]
    public class ConsultIntentReply : IIntentReplier
    {
        private IEntityReplier _repliers;


        public ConsultIntentReply()
        {
            _repliers = new HeroReply(new PlayerIdReply());
        }

        public async void Reply(IDialogContext context, LuisResult result)
        {
            Task.Run(() => _repliers.Reply(context, result.Entities));
        }
    }
}