using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies
{
    public interface IIntentReplier
    {
        void Reply(IDialogContext context, LuisResult result);
    }
}
