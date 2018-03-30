using BotApp.Replies;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotApp.Dialogs
{
    [Serializable]
    [LuisModel("ff11472d-e2d7-47ef-9a56-a8525fceec7e", "d76b2e94045a48fb8f4e00569dc3d739")]
    public class DotaDialog : LuisDialog<object>
    {
        private Dictionary<string, IIntentReplier> Repliers;

        public DotaDialog()
        {
            Repliers = new Dictionary<string, IIntentReplier>()
            {
                { "Consult", new ConsultIntentReply() },
                { "Register", new RegisterIntentReply() },
                { "Update", new UpdateIntentReply() },
                { "Compliment", new ComplimentIntentReply() }
            };
        }

        [LuisIntent("Consult")]
        public Task Consult(IDialogContext context, LuisResult result)
        {
            Repliers["Consult"].Reply(context, result);
            return Task.CompletedTask;
        }

        [LuisIntent("Update")]
        public Task Update(IDialogContext context, LuisResult result)
        {
            Task.Run(() => Repliers["Update"].Reply(context, result));
            return Task.CompletedTask;
        }

        [LuisIntent("Register")]
        public Task Register(IDialogContext context, LuisResult result)
        {
            Repliers["Register"].Reply(context, result);
            return Task.CompletedTask;
        }

        [LuisIntent("Compliment")]
        public Task Compliment(IDialogContext context, LuisResult result)
        {
            Repliers["Compliment"].Reply(context, result);
            return Task.CompletedTask;
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry! I don't know what you're talking about, I only know about Dota 2!");
        }

    }
}