using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies.Entities
{
    public class RegisterPlayerIdReply : IEntityReplier
    {
        public async void Reply(IDialogContext context, EntityRecommendation result)
        {
            if (result.Type == "PlayerId")
            {
                if(!DotaApp.PlayerIds.Any(x=> x == result.Entity))
                    DotaApp.PlayerIds.Add(result.Entity);
                await context.PostAsync($"PlayerId [{result.Entity}] with success!");
            }
        }
    }
}