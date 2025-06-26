using System;

namespace ProgPOEP3
{
    public class SecurityTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{(IsCompleted ? "✅" : "🕒")} {Title} - {Description}" +
                   (ReminderDate.HasValue ? $" (⏰ Reminder: {ReminderDate.Value.ToShortDateString()})" : "");
        }
    }
}
