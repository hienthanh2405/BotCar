using ChatBotNetCoreSample.Services;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Controllers
{
    public class HelloBot : IBot
    {
        public async Task OnTurn(ITurnContext context)
        {
            if (context.Activity.Type is ActivityTypes.Message)
            {
                string message = context.Activity.Text;
                NLPRepository nlp = new NLPRepository();
                string reply = nlp.GetReply(message);
                await context.SendActivity(reply);

            }
        }
       
    }
}
