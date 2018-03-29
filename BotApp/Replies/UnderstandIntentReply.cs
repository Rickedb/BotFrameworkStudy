using BotApp.Replies.Entities;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;


namespace BotApp.Replies
{
    [Serializable]
    public class UnderstandIntentReply : IIntentReplier
    {
        private IEntityReplier _repliers;
        

        public UnderstandIntentReply()
        {
            _repliers = new HeroReply();
        }

        public async void Reply(IDialogContext context, LuisResult result)
        {
            var entity = result.Entities.FirstOrDefault();

            if (entity != null)
                _repliers.Reply(context, entity);
            else
                await context.PostAsync("Don't know what you're talking about!");
        }
    }
}