using System;
using System.Collections.Generic;

namespace CyberSecurityBotApp.Models
{
    public class ActivityLogger
    {
        private List<string> logEntries = new List<string>();
        private int maxLogSize = 10;

        public void LogAction(string action)
        {
            logEntries.Add(action);
            if (logEntries.Count > maxLogSize)
            {
                logEntries.RemoveAt(0); // Remove the oldest entry if the log exceeds the maximum size
            }
        }

        public string GetLog()
        {
            return string.Join("\n", logEntries);
        }

        public string GetLimitedLog(int limit = 5)
        {
            return string.Join("\n", logEntries.GetRange(logEntries.Count - Math.Min(limit, logEntries.Count), Math.Min(limit, logEntries.Count)));
        }
    }
}