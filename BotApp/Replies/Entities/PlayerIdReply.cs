using BotApp.Models;
using BotApp.Repositories;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApp.Replies.Entities
{
    [Serializable]
    public class PlayerIdReply : IEntityReplier
    {
        private readonly IDotaRepository _dotaRepository;

        public PlayerIdReply()
        {
            _dotaRepository = new DotaRepository();
        }

        public async void Reply(IDialogContext context, IList<EntityRecommendation> result)
        {
            var entity = result.FirstOrDefault(x => x.Type == "PlayerId");

            if (entity != null)
            {
                Activity response = ((Activity)context.Activity).CreateReply();

                var player = await _dotaRepository.GetPlayer(entity.Entity);

                if (player != null)
                {
                    var card = new HeroCard
                    {
                        Title = player.Profile.Nickname,
                        Images = new List<CardImage>() { new CardImage(player.Profile.AvatarUrl) },
                        Text = GetPlayerText(player)
                    };

                    response.Attachments.Add(card.ToAttachment());
                }
                else
                    response.Text = $"I don't know which player is {entity.Entity}, maybe it's wrong or does not exists!";

                await context.PostAsync(response);
            }
        }

        private string GetPlayerText(Player player)
        {
            return $@"Tracked Until: [{player.TrackedUntil}]{Environment.NewLine}
Team Rank: [{player.TeamRank}]{Environment.NewLine}
Solo Rank: [{player.SoloRank}]{Environment.NewLine}
LeaderboardRank: [{player.TrackedUntil}]{Environment.NewLine}
Rank Tier: [{player.TrackedUntil}]{Environment.NewLine}
Estimated MMR: [{player.EstimatedMmr.Estimated}]{Environment.NewLine}
Account Id: [{player.Profile.AccountId}]{Environment.NewLine}
Steam Id: [{player.Profile.SteamId}]{Environment.NewLine}
Country Code: [{player.Profile.CountryCode}]";
        }
    }
}