using System;
using System.Text.RegularExpressions;

namespace ProgPOEP3
{
    public static class ReminderHelper
    {
        public static DateTime? ExtractReminderDate(string message)
        {
            // Matches phrases like "remind me in 3 days"
            var match = Regex.Match(message, @"remind me in (\d+)\s*(day|days|week|weeks)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int amount = int.Parse(match.Groups[1].Value);
                string unit = match.Groups[2].Value.ToLower();

                if (unit.Contains("week"))
                    return DateTime.Now.AddDays(amount * 7);
                else
                    return DateTime.Now.AddDays(amount);
            }

            return null;
        }
    }
}
