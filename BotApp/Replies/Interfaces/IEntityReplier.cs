using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;

namespace BotApp.Replies
{
    public interface IEntityReplier
    {
        void Reply(IDialogContext context, IList<EntityRecommendation> result);
    }
}
