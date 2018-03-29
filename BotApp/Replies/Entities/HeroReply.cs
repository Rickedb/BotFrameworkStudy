﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BotApp.Helpers;
using BotApp.Models;
using Hangfire;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace BotApp.Replies.Entities
{
    [Serializable]
    public class HeroReply : IEntityReplier
    {
        private readonly IEntityReplier _nextReply;
        private const string _entity = "hero";
        
        public HeroReply()
        {

        }

        public async void Reply(IDialogContext context, EntityRecommendation result)
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