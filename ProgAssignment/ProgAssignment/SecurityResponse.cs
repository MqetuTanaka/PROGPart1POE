using System;
using System.Collections.Generic;

namespace CyberSecurityBotApp.Models
{
    public class SecurityResponse : BotResponse
    {
        public string ExtendedResponse { get; set; }

        public SecurityResponse(string trigger, string response) : base(trigger, response)
        {
        }

        public override string GetResponse()
        {
            // Check if there are random responses and randomly pick one
            if (Responses.Count > 0 && new Random().Next(0, 2) == 0)
            {
                return Responses[new Random().Next(0, Responses.Count)];
            }
            // Otherwise, return the ExtendedResponse or fall back to the base Response
            return ExtendedResponse ?? Response;
        }
    }
}