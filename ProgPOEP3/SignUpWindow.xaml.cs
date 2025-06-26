using System.IO;
using System.Linq;
using System.Windows;

namespace ProgPOEP3
{
    public partial class SignUpWindow : Window
    {
        private string usersFile = "users.txt";

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string newUser = NewUsername.Text.Trim();

            if (string.IsNullOrEmpty(newUser))
            {
                StatusText.Text = "Please enter a username.";
                return;
            }

            if (!File.Exists(usersFile))
            {
                File.Create(usersFile).Close();
            }

            var allUsers = File.ReadAllLines(usersFile);

            if (allUsers.Contains(newUser))
            {
                StatusText.Text = "Username already exists. Choose another.";
            }
            else
            {
                File.AppendAllText(usersFile, newUser + "\n");
                StatusText.Text = "Registration successful!";
            }
        }
    }
}
