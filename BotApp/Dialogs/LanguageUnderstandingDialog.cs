using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Dialogs
{
    [LuisModel("95fb7328-6ed2-4394-9381-7993bc89f969", "d76b2e94045a48fb8f4e00569dc3d739")]
    public class LanguageUnderstandingDialog : LuisDialog<object>
    {

        [LuisIntent("Command")]
        public async Task Command(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Command intent");
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("No intent");
        }
    }
}