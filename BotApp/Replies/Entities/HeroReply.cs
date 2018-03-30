using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BotApp.Replies.Entities
{
    [Serializable]
    public class HeroReply : IEntityReplier
    {
        private readonly IEntityReplier _nextReply;
        private const string _entity = "hero";
        
        public HeroReply(IEntityReplier next)
        {
            _nextReply = next;
        }

        public async void Reply(IDialogContext context, IList<EntityRecommendation> result)
        {
            var entity = result.FirstOrDefault(x => x.Type == "Hero");
            if (entity != null)
            {
                Activity response = ((Activity)context.Activity).CreateReply();
                var hero = DotaApp.Heroes.FirstOrDefault(x => x.Name.ToLower().Equals(entity.Entity.ToLower()));

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
                    response.Text = $"I don't know which hero is [{entity.Entity}]";

                await context.PostAsync(response);
                return;
            }

            _nextReply.Reply(context, result);
        }
    }
}