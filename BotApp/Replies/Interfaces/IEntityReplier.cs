using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp.Replies
{
    public interface IEntityReplier
    {
        void Reply(IDialogContext context, EntityRecommendation result);
    }
}
