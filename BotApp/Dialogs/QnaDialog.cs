using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Dialogs
{
    [Serializable]
    public class QnaDialog : QnAMakerDialog
    {
        public QnaDialog() : base(new QnAMakerService(new QnAMakerAttribute(WebApiConfig.SubscriptionKey, WebApiConfig.KnowledgeBaseId, "Don't know what you talking about!", 0.5)))
        {

        }

        protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
        {
            var responseFromBase = result.Answers.FirstOrDefault();

            Activity response = ((Activity)context.Activity).CreateReply();
            var texts = responseFromBase.Answer.Split(';');

            if(texts.Length == 1)
            {
                response.Text = responseFromBase.Answer;
                await context.PostAsync(response);
                return;
            }

            HeroCard card = new HeroCard
            {
                Title = responseFromBase.Questions.FirstOrDefault(),
                Images = new List<CardImage>(),
                Text = string.Empty
            };
            foreach (var t in texts)
            {
                if (t.Contains(".jpg") || t.Contains(".png"))
                    card.Images.Add(new CardImage(t.Trim()));
                else
                    card.Text += t;
            }
            response.Attachments.Add(card.ToAttachment());

            await context.PostAsync(response);
        }
    }
}