using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProgPOEP3
{
    public partial class QuizWindow : Window
    {
        private readonly string currentUsername;
        private List<QuizQuestion> questions;
        private int currentIndex = 0;
        private int score = 0;
        private List<string> missedTopics = new List<string>();
        private List<string> missedFeedback = new List<string>();


        public QuizWindow(string username)
        {
            InitializeComponent();
            currentUsername = username;
            questions = QuizData.GetQuestions();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                ShowFinalFeedback();
                return;
            }

            var question = questions[currentIndex];
            QuestionText.Text = $"Q{currentIndex + 1}: {question.Question}";
            AnswerList.Items.Clear();

            foreach (var option in question.Options)
            {
                var item = new ListBoxItem
                {
                    Content = option,
                    Background = System.Windows.Media.Brushes.White
                };
                AnswerList.Items.Add(item);
            }

            AnswerList.IsEnabled = true;
            SubmitAnswer.IsEnabled = true;
            FeedbackText.Text = "";
        }

        private async void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerList.SelectedIndex == -1)
            {
                FeedbackText.Text = "⚠️ Please select an answer.";
                FeedbackText.Foreground = System.Windows.Media.Brushes.DarkRed;
                return;
            }

            var question = questions[currentIndex];
            var isCorrect = AnswerList.SelectedIndex == question.CorrectIndex;

            // Color feedback
            for (int i = 0; i < AnswerList.Items.Count; i++)
            {
                var item = (ListBoxItem)AnswerList.ItemContainerGenerator.ContainerFromIndex(i);
                if (i == question.CorrectIndex)
                {
                    item.Background = System.Windows.Media.Brushes.LightGreen;
                }
                else if (i == AnswerList.SelectedIndex && !isCorrect)
                {
                    item.Background = System.Windows.Media.Brushes.LightCoral;
                }
            }

            if (isCorrect)
            {
                FeedbackText.Text = question.Feedback;
                FeedbackText.Foreground = System.Windows.Media.Brushes.Green;
                score++;
            }
            else
            {
                FeedbackText.Text = $"❌ Incorrect. {question.Feedback}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.DarkRed;
                missedTopics.Add(GetTopicFromQuestion(question.Question));
                missedFeedback.Add($"Q{currentIndex + 1}: {question.Feedback}");
            }

            // Disable further selection
            AnswerList.IsEnabled = false;
            SubmitAnswer.IsEnabled = false;

            // Wait and load next question
            await Task.Delay(2000); // wait 2 seconds before moving on
            currentIndex++;
            LoadQuestion();
        }

        private void ShowFinalFeedback()
        {
            double percentage = (double)score / questions.Count * 100;
            string summary = $"🎉 Great job, {currentUsername}! You scored {score}/{questions.Count} ({percentage:F1}%).\n";

            if (missedTopics.Any())
            {
                var advice = string.Join(", ", missedTopics.Distinct());
                summary += $"📝 Based on your answers, consider reviewing these topics: {advice}.\n";

                if (missedFeedback.Any())
                {
                    summary += "\n❌ Here's what you got wrong:\n";
                    foreach (var feedback in missedFeedback)
                    {
                        summary += $"• {feedback}\n";
                    }
                }
            }
            else
            {
                summary += "✅ Excellent! You answered all questions correctly.";
            }

            MessageBox.Show(summary, "Quiz Summary", MessageBoxButton.OK, MessageBoxImage.Information);

            QuestionText.Text = "📘 Quiz completed.";
            FeedbackText.Text = "You can retry the quiz or go to the chatbot.";
            AnswerList.Items.Clear();
            SubmitAnswer.IsEnabled = false;
            RetryButton.Visibility = Visibility.Visible;
        }



        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex = 0;
            score = 0;
            missedTopics.Clear();
            SubmitAnswer.IsEnabled = true;
            RetryButton.Visibility = Visibility.Hidden;
            LoadQuestion();
        }

        private string GetTopicFromQuestion(string question)
        {
            if (question.ToLower().Contains("password")) return "Password Safety";
            if (question.ToLower().Contains("phishing")) return "Phishing Awareness";
            if (question.ToLower().Contains("vpn")) return "VPN Knowledge";
            if (question.ToLower().Contains("two-factor")) return "Authentication Methods";
            return "General Cybersecurity";
        }

        private void GoToChatbot_Click(object sender, RoutedEventArgs e)
        {
            ChatbotWindow botWindow = new ChatbotWindow(currentUsername);
            botWindow.Show();
            this.Close();
        }
    }
}
