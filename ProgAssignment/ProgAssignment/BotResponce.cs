using System;
using System.Collections.Generic;

namespace CyberSecurityBotApp.Models
{
    public abstract class BotResponse
    {
        public string Trigger { get; set; }
        public string Response { get; set; }
        public List<string> Responses { get; set; } = new List<string>();
        public string ExtendedResponse { get; set; }

        public BotResponse(string trigger, string response)
        {
            Trigger = trigger;
            Response = response;
        }

        public virtual string GetResponse()
        {
            if (Responses.Count > 0 && new Random().Next(0, 2) == 0)
            {
                return Responses[new Random().Next(0, Responses.Count)];
            }
            return Response;
        }

        public void AddRandomResponse(string response)
        {
            Responses.Add(response);
        }
    }
}