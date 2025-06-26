using System;

namespace ProgPOEP3
{
    public static class NLPHelper
    {
        public static string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("how do i") || input.Contains("can you help me with") || input.Contains("teach me"))
                return "learn";

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("unsafe"))
                return "worried";

            if (input.Contains("i'm curious") || input.Contains("tell me more") || input.Contains("what is"))
                return "curious";

            if (input.Contains("annoyed") || input.Contains("tired of") || input.Contains("frustrated"))
                return "frustrated";

            if (input.Contains("phishing")) return "phishing";
            if (input.Contains("vpn")) return "vpn";
            if (input.Contains("password")) return "password";
            if (input.Contains("malware")) return "malware";

            return "unknown";
        }
    }
}
