using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies
{
    [Serializable]
    public class ComplimentIntentReply : IIntentReplier
    {
        public async void Reply(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hello! I'm Dota Bot! I know a lot about that game, I love it!");
            await context.PostAsync("I have some available commands:");
            await context.PostAsync(GetCommands());
        }

        private string GetCommands()
        {
            return $@"Hero [HeroName] - Show information about a hero{Environment.NewLine}
Player [PlayerId] - show information about a player{Environment.NewLine}
Register [PlayerId] - make me start to watch your recent games{Environment.NewLine}
Refresh - Show all NEW recent games from registered PlayerIds{Environment.NewLine}
Although you can try to talk these commands with your words, I will try to translate it to my robot bit language HEHE!";
        }
    }
}