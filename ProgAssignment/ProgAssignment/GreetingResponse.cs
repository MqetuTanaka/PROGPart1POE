using System;

namespace CyberSecurityBotApp.Models
{
    public class GreetingResponse : BotResponse
    {
        public string UserName { get; set; }

        public GreetingResponse(string userName) : base("greeting", "Hello! How can I help you today?")
        {
            UserName = userName;
            // Initialize Responses with at least one element before accessing index 0
            Responses.Add("Default response");
            Responses[0] = $"Welcome {userName}! Ready to boost your cybersecurity knowledge?";
            AddRandomResponse($"Hello {userName}! How can I help you stay secure today?");
            AddRandomResponse($"Greetings {userName}! Let's make your digital life more secure!");
        }

        public override string GetResponse()
        {
            return $"Hello {UserName}! How can I help you today?";
        }
    }
}