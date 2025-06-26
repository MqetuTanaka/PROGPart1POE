using ProgPOEP3;
using System;
using System.Collections.Generic;
using System.Linq;

public static class TaskManager
{
    public static List<SecurityTask> Tasks = new List<SecurityTask>();

    public static void AddTask(string title, string description, DateTime? reminder = null)
    {
        Tasks.Add(new SecurityTask
        {
            Title = title,
            Description = description,
            ReminderDate = reminder,
            IsCompleted = false
        });
    }

    public static string ListTasks()
    {
        if (Tasks.Count == 0)
            return "📭 No tasks have been added yet.";

        return string.Join("\n\n", Tasks.Select((t, i) => $"{i + 1}. {t}"));
    }

    public static bool CompleteTask(int index)
    {
        if (index < 0 || index >= Tasks.Count) return false;
        Tasks[index].IsCompleted = true;
        return true;
    }

    public static bool DeleteTask(int index)
    {
        if (index < 0 || index >= Tasks.Count) return false;
        Tasks.RemoveAt(index);
        return true;
    }
}
