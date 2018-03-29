using System.Linq;
using BotApp.Replies.Entities;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies
{
    public class RegisterIntentReply : IIntentReplier
    {
        private readonly IEntityReplier _repliers;

        public RegisterIntentReply()
        {
            _repliers = new PlayerIdEntity();
        }

        public async void Reply(IDialogContext context, LuisResult result)
        {
            var entity = result.Entities.FirstOrDefault();

            if (entity != null)
                _repliers.Reply(context, entity);
            else
                await context.PostAsync("I didn't understand what you want to register!");
        }
    }
}