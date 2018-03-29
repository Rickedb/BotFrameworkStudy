using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApp.Dialogs
{
    public class DebuggerDialog<T> : IDialog<object>
    {
        private readonly IDialog<T> _dialog;

        public DebuggerDialog(IDialog<T> dialog)
        {
            _dialog = dialog;
        }

        public async Task StartAsync(IDialogContext context)
        {
            try
            {
                context.Call(_dialog, ResumeAsync);
            }
            catch(Exception ex)
            {

            }
        }

        private async Task ResumeAsync(IDialogContext context, IAwaitable<T> result)
        {
            try
            {
                context.Done(await result);
            }
            catch(Exception ex)
            {
            }
        }
    }
}