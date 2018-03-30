using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies.Entities
{
    [Serializable]
    public class RegisterPlayerIdReply : IEntityReplier
    {
        public async void Reply(IDialogContext context, IList<EntityRecommendation> result)
        {
            var entity = result.FirstOrDefault(x => x.Type == "PlayerId");
            if (entity != null)
            {
                if(!DotaApp.PlayerIds.Any(x=> x == entity.Entity))
                    DotaApp.PlayerIds.Add(entity.Entity);
                await context.PostAsync($"PlayerId [{entity.Entity}] registered with success!");
            }
        }
    }
}