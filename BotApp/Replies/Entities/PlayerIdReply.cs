using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApp.Replies.Entities
{
    public class PlayerIdReply : IEntityReplier
    {
        public async void Reply(IDialogContext context, EntityRecommendation result)
        {
            if (result.Type == "PlayerId")
            {
                Activity response = ((Activity)context.Activity).CreateReply();

                if (result.Type == "Hero")
                {
                    var hero = DotaApp.Heroes.FirstOrDefault(x => x.Name.ToLower().Equals(result.Entity.ToLower()));

                    if (hero != null)
                    {
                        var card = new HeroCard
                        {
                            Title = hero.Name,
                            Subtitle = hero.PrimaryAttribute
                        };

                        response.Attachments.Add(card.ToAttachment());
                    }
                    else
                        response.Text = $"I don't know which hero is {result.Entity}";
                }

                await context.PostAsync(response);
            }
        }
    }
}