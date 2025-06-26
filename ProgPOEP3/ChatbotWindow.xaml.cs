using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProgPOEP3
{
    public partial class ChatbotWindow : Window
    {
        private readonly string currentUsername;
        private string currentTopic = null;
        private string favoriteTopic = null;

        public ChatbotWindow(string username)
        {
            InitializeComponent();
            currentUsername = username;
            GreetingText.Text = $"🤖 Hello, {currentUsername}! I'm your 🛡️ Security Bot. Ask me anything about cybersecurity!";
            ActivityLog.AddLog($"Entered chatbot as '{currentUsername}'");
            string question = QuestionInput.Text.Trim().ToLower();
        }

        private void AppendToChat(string message, bool isUser)
        {
            var bubble = new TextBlock
            {
                Text = (isUser ? $"🧑 {currentUsername}:\n" : "🤖 Bot:\n") + message,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                Background = isUser ? System.Windows.Media.Brushes.LightBlue : System.Windows.Media.Brushes.LightGray,
                Padding = new Thickness(10),
                MaxWidth = 500
            };

            DialogueStack.Children.Add(bubble);

            // Auto scroll to bottom
            ChatScrollViewer.ScrollToEnd();
        }


        private void CheckTaskReminders()
        {
            var dueTasks = TaskManager.Tasks
                .Where(t => t.ReminderDate != null && t.ReminderDate <= DateTime.Now && !t.IsCompleted)
                .ToList();

            if (dueTasks.Any())
            {
                string reminderText = "⏰ Reminder(s):\n";
                foreach (var task in dueTasks)
                {
                    reminderText += $"• {task.Title} — {task.Description}\n";
                }

                MessageBox.Show(reminderText, "Task Reminders", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void Ask_Click(object sender, RoutedEventArgs e)
        {
            string question = QuestionInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(question))
            {
                AddMessageToDialogue($"❗ Please enter a question, {currentUsername}.", isUser: false);
                return;
            }

            // Show user's message in chat
            AddMessageToDialogue($"🧑‍💻 You: {question}", isUser: true);

            string lowerQuestion = question.ToLower();
            string response = "";

            try
            {
                // ✨ NLP enhancements: Common phrases
                if (lowerQuestion.Contains("start quiz") || lowerQuestion.Contains("take quiz") || lowerQuestion.Contains("do the quiz") || lowerQuestion.Contains("start test"))
                {
                    ActivityLog.AddLog("User entered Quiz from chatbot");
                    QuizWindow quizWindow = new QuizWindow(currentUsername);
                    quizWindow.Show();
                    this.Close();
                    return;
                }
                else if (lowerQuestion.Contains("show activity log") || lowerQuestion.Contains("activity summary") || lowerQuestion.Contains("what have you done") || lowerQuestion.Contains("log of past actions") || lowerQuestion.Contains("show log"))
                {
                    response = ActivityLog.GetFormattedLogs();
                }
                else if (lowerQuestion.StartsWith("add a task to") || lowerQuestion.StartsWith("schedule task to") || lowerQuestion.StartsWith("add task to"))
                {
                    string taskTitle = question
                        .Replace("add a task to", "")
                        .Replace("schedule task to", "")
                        .Replace("add task to", "").Trim();

                    if (string.IsNullOrEmpty(taskTitle))
                    {
                        response = $"📝 Please provide a task description.";
                    }
                    else
                    {
                        TaskManager.AddTask(taskTitle, $"Task: {taskTitle}");
                        ActivityLog.AddLog($"Task added: '{taskTitle}'");
                        response = $"✅ Task added: \"{taskTitle}\".\nWould you like to set a reminder for this task?";
                    }
                }
                else if (lowerQuestion.Contains("what tasks do i have") || lowerQuestion.Contains("show my tasks") ||
                         lowerQuestion.Contains("list tasks") || lowerQuestion.Contains("task list") || lowerQuestion.Contains("security checklist"))
                {
                    response = TaskManager.ListTasks();
                }
                else if (lowerQuestion.StartsWith("remind me to"))
                {
                    string taskTitle = lowerQuestion.Replace("remind me to", "").Trim();
                    var reminderDate = ReminderHelper.ExtractReminderDate(lowerQuestion);

                    if (reminderDate.HasValue)
                    {
                        TaskManager.AddTask(taskTitle, $"Reminder Task: {taskTitle}", reminderDate);
                        ActivityLog.AddLog($"Reminder task added: '{taskTitle}' for {reminderDate.Value.ToShortDateString()}");
                        response = $"🔔 Reminder set for '{taskTitle}' on {reminderDate.Value.ToShortDateString()}.";
                    }
                    else
                    {
                        response = $"⚠️ I couldn't understand the date for the reminder. Try saying something like 'Remind me to check firewall in 3 days'.";
                    }
                }
                // 🔐 Built-in logic
                else if (lowerQuestion.Contains("how are you"))
                {
                    response = $"😊 I'm great, {currentUsername}! Just running smoothly in the system.";
                }
                else if (lowerQuestion.Contains("your purpose"))
                {
                    response = $"🎯 My mission is to teach you about cybersecurity basics and keep you informed.";
                }
                else if (lowerQuestion.Contains("what can i ask"))
                {
                    response = @"📚 You can ask me about:
🔐 Password safety
🎣 Phishing
🛡️ VPNs
🌐 Secure browsing
🐛 Malware
...and more!";
                }
                else if (lowerQuestion.Contains("advice") || lowerQuestion.Contains("next"))
                {
                    if (!string.IsNullOrEmpty(favoriteTopic))
                    {
                        response = $"🔎 As someone interested in {favoriteTopic}, {currentUsername}, you might want to review your privacy settings and use strong authentication methods.";
                    }
                    else
                    {
                        response = $"📝 Good question, {currentUsername}. Start with strong passwords, enable 2FA, and be cautious of phishing scams.";
                    }
                }
                else if (lowerQuestion.StartsWith("add task"))
                {
                    string taskTitle = question.Substring(8).Trim();
                    if (string.IsNullOrEmpty(taskTitle))
                    {
                        response = $"📝 Please provide a task name.";
                    }
                    else
                    {
                        TaskManager.AddTask(taskTitle, $"Task: {taskTitle}");
                        ActivityLog.AddLog($"Task added: '{taskTitle}'");
                        response = $"✅ Task added: \"{taskTitle}\".\nWould you like a reminder?";
                    }
                }
                else if (lowerQuestion.Contains("remind me in"))
                {
                    var reminderDate = ReminderHelper.ExtractReminderDate(question);
                    if (reminderDate.HasValue && TaskManager.Tasks.Count > 0)
                    {
                        int days = (reminderDate.Value - DateTime.Now).Days;
                        var lastTask = TaskManager.Tasks.Last();
                        lastTask.ReminderDate = reminderDate.Value;
                        ActivityLog.AddLog($"Reminder set for task '{lastTask.Title}' in {days} day(s)");
                        response = $"⏰ Got it! I’ll remind you to \"{lastTask.Title}\" in {days} day(s), {currentUsername}.";
                    }
                    else
                    {
                        response = "⚠️ No task found to add a reminder to.";
                    }
                }
                else if (lowerQuestion.Contains("show tasks"))
                {
                    response = TaskManager.ListTasks();
                }
                else if (lowerQuestion.StartsWith("complete task"))
                {
                    if (int.TryParse(lowerQuestion.Replace("complete task", "").Trim(), out int index))
                    {
                        bool success = TaskManager.CompleteTask(index - 1);
                        if (success) ActivityLog.AddLog($"Task {index} marked as completed");
                        response = success ? $"🎉 Task {index} marked as completed!" : "⚠️ Invalid task number.";
                    }
                    else
                    {
                        response = "❓ Please specify the task number (e.g. complete task 2).";
                    }
                }
                else if (lowerQuestion.StartsWith("delete task"))
                {
                    if (int.TryParse(lowerQuestion.Replace("delete task", "").Trim(), out int index))
                    {
                        bool success = TaskManager.DeleteTask(index - 1);
                        if (success) ActivityLog.AddLog($"Task {index} deleted");
                        response = success ? $"🗑️ Task {index} deleted!" : "⚠️ Could not delete task.";
                    }
                    else
                    {
                        response = "❓ Please specify the task number (e.g. delete task 2).";
                    }
                }
                else
                {
                    // Fallback to topics
                    string topic = TopicHelper.ExtractTopic(question);

                    if (lowerQuestion.Contains("more") || lowerQuestion.Contains("explain") || lowerQuestion.Contains("details"))
                    {
                        if (!string.IsNullOrEmpty(currentTopic))
                        {
                            response = CyberSecurityResponses.GetResponse(currentTopic);
                            response = $@"📌 Here's more on {currentTopic}, {currentUsername}:
{response}";
                        }
                        else
                        {
                            response = $"❓ More on what exactly? Try asking about topics like passwords, phishing, or malware.";
                        }
                    }
                    else if (!string.IsNullOrEmpty(topic))
                    {
                        currentTopic = topic;
                        if (favoriteTopic == null && lowerQuestion.Contains("interested in"))
                        {
                            favoriteTopic = topic;
                            response = $"👍 Great! I'll remember that you're interested in {topic}, {currentUsername}. It's an essential part of staying safe online.";
                        }
                        else
                        {
                            response = CyberSecurityResponses.GetResponse(topic);
                            response = $@"✅ {currentUsername}, here's something on {topic}:
{response}";
                        }
                    }
                    else
                    {
                        response = $"🤔 I'm still learning about that topic, {currentUsername}. Try asking about something like malware, phishing, or VPNs.";
                    }
                }

                // 🧠 Sentiment-aware feedback
                string intent = NLPHelper.DetectIntent(question);
                switch (intent)
                {
                    case "worried":
                        response += $"\n💬 It's okay to feel worried, {currentUsername}. Cybersecurity can be confusing, but you're doing the right thing.";
                        break;
                    case "curious":
                        response += $"\n🧠 Great curiosity, {currentUsername}! Let's explore more.";
                        break;
                    case "frustrated":
                        response += $"\n😓 I understand it's frustrating. Let’s break it down together.";
                        break;
                    case "learn":
                        response += $"\n📘 Want to learn more? Ask me about phishing, passwords, or VPNs.";
                        break;
                }

                AddMessageToDialogue($"🤖 Bot: {response}", isUser: false);
                QuestionInput.Text = "";
            }
            catch (Exception ex)
            {
                AddMessageToDialogue($"⚠️ Something went wrong: {ex.Message}", isUser: false);
            }
        }



        private void AddMessageToDialogue(string message, bool isUser)
        {
            var bubble = new Border
            {
                Background = isUser ? System.Windows.Media.Brushes.DeepSkyBlue : System.Windows.Media.Brushes.MediumSeaGreen,
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(5),
                Padding = new Thickness(10),
                HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                MaxWidth = 300,
                BorderThickness = new Thickness(1),
                BorderBrush = System.Windows.Media.Brushes.WhiteSmoke
            };

            var text = new TextBlock
            {
                Text = message,
                Foreground = System.Windows.Media.Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Bold,
                FontSize = 14
            };

            bubble.Child = text;
            DialogueStack.Children.Add(bubble);

            // Auto-scroll to bottom
            ChatScrollViewer.ScrollToEnd();
        }


        private async Task SimulateTyping(string fullText)
        {
            ResponseBox.Text = "";
            foreach (char c in fullText)
            {
                ResponseBox.Text += c;
                await Task.Delay(15);
                DoEvents();
            }
        }

        private void GoToQuiz_Click(object sender, RoutedEventArgs e)
        {
            ActivityLog.AddLog("Navigated to Quiz");
            QuizWindow quizWindow = new QuizWindow(currentUsername);
            quizWindow.Show();
            this.Close();
        }

        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(delegate (object f)
                {
                    ((DispatcherFrame)f).Continue = false;
                    return null;
                }), frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
