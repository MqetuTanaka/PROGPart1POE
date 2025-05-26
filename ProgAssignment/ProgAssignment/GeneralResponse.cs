using System;
using System.Collections.Generic;

namespace CyberSecurityBotApp.Models
{
    public class GeneralResponse : BotResponse
    {
        public List<string> Keywords { get; set; } = new List<string>();

        public GeneralResponse(string trigger, string response, List<string> keywords = null) : base(trigger, response)
        {
            if (keywords != null)
            {
                Keywords.AddRange(keywords);
            }
        }

        public void AddRandomResponse(string response)
        {
            SecurityResponse securityResponse = new SecurityResponse("phishing", "Be cautious of phishing attempts.");
            securityResponse.AddRandomResponse("Phishing emails often create a sense of urgency.");
            securityResponse.AddRandomResponse("Always check the sender's email address carefully.");
            securityResponse.AddRandomResponse("Hover over links to see where they really lead.");
        }
    }
}