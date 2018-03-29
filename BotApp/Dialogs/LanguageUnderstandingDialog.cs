using BotApp.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Dialogs
{
    [Serializable]
    [LuisModel("ff11472d-e2d7-47ef-9a56-a8525fceec7e", "d76b2e94045a48fb8f4e00569dc3d739")]
    public class LanguageUnderstandingDialog : LuisDialog<object>
    {
        public LanguageUnderstandingDialog() : base()
        {
        }

        protected override Task<string> GetLuisQueryTextAsync(IDialogContext context, IMessageActivity message)
        {
            return base.GetLuisQueryTextAsync(context, message);
        }


        [LuisIntent("Understand")]
        public async Task Understand(IDialogContext context, LuisResult result)
        {
            var entity = result.Entities.FirstOrDefault();
            Activity response = ((Activity)context.Activity).CreateReply();

            
            if (entity.Type == "Hero")
            {
                using (var request = new HttpClient())
                {
                    var dotaResponse = await request.GetAsync("https://api.opendota.com/api/heroes");

                    if(dotaResponse.IsSuccessStatusCode)
                    {
                        var json = await dotaResponse.Content.ReadAsStringAsync();
                        var hero = JsonConvert.DeserializeObject<List<Hero>>(json).FirstOrDefault(x=> x.Name.ToLower().Equals(entity.Entity.ToLower()));

                        var card = new HeroCard
                        {
                            Title = hero.Name,
                            Subtitle = hero.PrimaryAttribute
                        };

                        response.Attachments.Add(card.ToAttachment());
                    }

                }
                    
               
            }

            await context.PostAsync(response);
        }

        [LuisIntent("Build")]
        public async Task Build(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("build intent");
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("No intent");
        }
    }
}