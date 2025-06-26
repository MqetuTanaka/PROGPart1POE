using System.Windows;

namespace ProgPOEP3
{
    public partial class ModeSelectionWindow : Window
    {
        private readonly string currentUsername;

        public ModeSelectionWindow(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder: Replace with your actual quiz window logic
            MessageBox.Show($"🧠 Quiz mode coming soon, {currentUsername}!");
        }

        private void Chatbot_Click(object sender, RoutedEventArgs e)
        {
            ChatbotWindow chatbot = new ChatbotWindow(currentUsername);
            chatbot.Show();
            this.Close();
        }
    }
}
