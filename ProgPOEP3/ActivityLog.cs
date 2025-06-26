using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgPOEP3
{
    public static class ActivityLog
    {
        private static List<Tuple<DateTime, string>> logEntries = new List<Tuple<DateTime, string>>();

        public static void AddLog(string action)
        {
            logEntries.Add(new Tuple<DateTime, string>(DateTime.Now, action));
            if (logEntries.Count > 100)
                logEntries.RemoveAt(0); // Keep log size reasonable
        }

        public static string GetFormattedLogs(int maxItems = 10)
        {
            var recentLogs = logEntries.Skip(Math.Max(0, logEntries.Count - maxItems)).ToList();
            if (recentLogs.Count == 0)
                return "📭 No recent activity to show.";

            string result = "🗒️ Recent Activity Log:\n";
            int count = 1;
            foreach (var entry in recentLogs)
            {
                result += string.Format("{0}. [{1:HH:mm}] {2}\n", count, entry.Item1, entry.Item2);
                count++;
            }
            return result;
        }

        public static void ClearLog()
        {
            logEntries.Clear();
        }

        public static List<string> GetAllRawEntries()
        {
            return logEntries.Select(e => string.Format("[{0:yyyy-MM-dd HH:mm:ss}] {1}", e.Item1, e.Item2)).ToList();
        }
    }
}
