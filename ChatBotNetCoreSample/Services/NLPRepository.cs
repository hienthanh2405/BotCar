using ChatBotNetCoreSample.Models;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Services
{
    public class NLPRepository
    {
        public string GetReply(string message)
        {
            string httpResponse = string.Empty;
            string url = @"https://api.wit.ai/message?v=20180618&q=" + message;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "Bearer XJUGVM3LOBK3WE7GJ4OBD6TNPHVLQ422");

            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                httpResponse = reader.ReadToEnd();
            }
            WitAiResponse witAiResponse = JsonConvert.DeserializeObject<WitAiResponse>(httpResponse);
            var reply = _convertWitAiResponseToReply(witAiResponse);

            return reply;

        }

        private string _convertWitAiResponseToReply(WitAiResponse witAiResponse)
        {
            if (witAiResponse.Entities.Intent == null)
            {
                return "Tôi không hiểu ý bạn cho lắm.";
            }

            string intent = witAiResponse.Entities.Intent[0].Value;

            if (intent == "greeting")
            {
                return "Xin chào, tôi là Chatbot. Tôi giúp gì được cho bạn?";
            }
            else if (intent == "price")
            {
                string productName = "";
                if (witAiResponse.Entities.Service != null)
                {
                    productName = "dịch vụ " + witAiResponse.Entities.Service[0].Value;
                }

                return string.Format("Giá của {0} là {1}", productName, 100000);
            }
            else if(intent == "service")
            {
                return "Bạn đang muốn hỏi về các dịch vụ của công ty";
            }
            else if(intent == "guarantee")
            {
                return "Bạn đang muốn hỏi về các chính sách bảo hành vỏ xe";
            }

            return "Chào";
        }

        private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "BotFramework Hero Card",
                Subtitle = "Your bots — wherever your users are talking",
                Text = "Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") }
            };

            return heroCard.ToAttachment();
        }
    }
}
