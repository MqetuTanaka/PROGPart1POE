using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ProgPOEP3
{
    public partial class MainWindow : Window
    {
        private readonly string usersFile = "users.txt";
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private string currentUsername;

        public MainWindow()
        {
            InitializeComponent();
            DisplayAsciiArt();
        }

        private void DisplayAsciiArt()
        {
            string asciiArt = @"
   _-_   _-   -_   _-_     _-_     _-_     _-_    _---_   __-__
  / __|  \ \ / /  | _ )   | __|   | _ \   | _ )   / _ \  |_   _|
 | (__    \ V /   | _ \   | _|    |   /   | _ \  | (_) |   | |  
  \___|   _|_|_   |___/   |___|   |_|_\   |___/   \___/   _|_|_ 
_|""""""""""|_| """""" |_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|_|""""""""""|
""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'""`-0-0-'
";
            AsciiTextBox.Text = asciiArt;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredName = UsernameInput.Text.Trim().ToLower().Replace(" ", "");
            char[] allowedChars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            enteredName = new string(enteredName.Where(c => allowedChars.Contains(c)).ToArray());

            if (!File.Exists(usersFile))
            {
                StatusText.Foreground = Brushes.DarkRed;
                StatusText.Text = "No users found. Please sign up.";
                return;
            }

            var allUsers = File.ReadAllLines(usersFile)
                               .Select(line => line.Trim().ToLower().Replace(" ", ""));

            if (allUsers.Contains(enteredName))
            {
                User loggedInUser = new User { Username = enteredName };
                StatusText.Foreground = Brushes.Green;
                StatusText.Text = $"Welcome back, {loggedInUser.Username}!";

                // 🎯 Redirect to Mode Selection Window
                ModeSelectionWindow modeWindow = new ModeSelectionWindow(loggedInUser.Username);
                modeWindow.Show();
                this.Close();
            }
            else
            {
                StatusText.Foreground = Brushes.Red;
                StatusText.Text = "❌ Username not found. Please check spelling or sign up first.";
            }
        }

        private void PlayGreetingAudio()
        {
            try
            {
                // Update this path to your real audio file location
                string fullPath = @"C:\Users\mqetu\source\repos\ProgPOEP3\Security Bot.wav";
                Uri audioUri = new Uri(fullPath, UriKind.Absolute);
                mediaPlayer.Open(audioUri);
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not play audio: {ex.Message}");
            }
        }

        private void OpenSignUp_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a SignUpWindow
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }
    }
}
