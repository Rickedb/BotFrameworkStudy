using BotApp.Replies.Entities;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;

namespace BotApp.Replies
{
    [Serializable]
    public class RegisterIntentReply : IIntentReplier
    {
        private readonly IEntityReplier _repliers;

        public RegisterIntentReply()
        {
            _repliers = new RegisterPlayerIdReply();
        }

        public void Reply(IDialogContext context, LuisResult result)
        {
            _repliers.Reply(context, result.Entities);
        }
    }
}