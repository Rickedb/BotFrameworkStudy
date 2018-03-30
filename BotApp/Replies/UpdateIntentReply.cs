using System;
using System.Linq;
using BotApp.Models;
using BotApp.Repositories;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BotApp.Replies
{
    [Serializable]
    public class UpdateIntentReply : IIntentReplier
    {
        public async void Reply(IDialogContext context, LuisResult result)
        {
            var queue = QueueRepository.Instance.GetQueueList();
            if (queue.Any())
            {
                foreach (var match in queue.OrderBy(x=> x.MatchId))
                {
                    Activity response = ((Activity)context.Activity).CreateReply();
                    var card = new HeroCard
                    {
                        Title = match.Player.Profile.Nickname,
                        Subtitle = $"{match.Winner} Won!",
                        Text = GetText(match)
                    };

                    response.Attachments.Add(card.ToAttachment());

                    await context.PostAsync(response);
                }
            }
            else
                await context.PostAsync("No new data to refresh!");
        }
        private string GetText(RecentMatches match)
        {
            return $@"
       Match Id: [{match.MatchId}]{Environment.NewLine}
           Hero: [{match.Hero.Name}]{Environment.NewLine}
    Player Slot: [{match.PlayerSlot}]{Environment.NewLine}
       Duration: [{match.DurationTime.ToString()}]{Environment.NewLine}
      Game Mode: [{match.GameMode}]{Environment.NewLine}
     Lobby Type: [{match.LobbyType}]{Environment.NewLine}
   Started Time: [{match.StartedTime.ToString()}]{Environment.NewLine}
          Kills: [{match.Kills}]{Environment.NewLine}
         Deaths: [{match.Deaths}]{Environment.NewLine}
        Assists: [{match.Assists}]{Environment.NewLine}
      Last Hits: [{match.LastHits}]{Environment.NewLine}
 Exp per Minute: [{match.ExpPerMinute}]{Environment.NewLine}
Gold per Minute: [{match.GoldPerMinute}]{Environment.NewLine}
    Hero Damage: [{match.HeroDamage}]{Environment.NewLine}
   Tower Damage: [{match.TowerDamage}]{Environment.NewLine}
   Hero Healing: [{match.HeroHealing}]{Environment.NewLine}
           Lane: [{match.Lane}]{Environment.NewLine}
      Lane Role: [{match.LaneRole}]{Environment.NewLine}
     Party Size: [{match.PartySize}]";
        }
    }
}