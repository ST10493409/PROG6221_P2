using System;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace CyberSecurityChatbot
{
    public partial class MainWindow : Window
    {
        Chatbot bot = new Chatbot();

        public MainWindow()
        {
            InitializeComponent();

            lstChat.Items.Add("Bot: Welcome to the Cybersecurity Awareness Bot!");

            lstChat.Items.Add("Bot: What is your favourite cybersecurity topic?");
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();

                string message = txtMessage.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Please enter your name and message.");

                    return;
                }

                bot.UserName = name;

                lstChat.Items.Add(name + ": " + message);

                string response = bot.GetResponse(message);

                await TypeEffect("Bot: " + response);

                txtMessage.Clear();
            }

            catch (Exception)
            {
                MessageBox.Show("An error occurred.");
            }
        }

        // Typing effects
        private async Task TypeEffect(string text)
        {
            lstChat.Items.Add("");

            int index = lstChat.Items.Count - 1;

            for (int i = 0; i <= text.Length; i++)
            {
                lstChat.Items[index] = text.Substring(0, i);

                await Task.Delay(20);
            }
        }
        private void btnQuiz_Click(object sender, RoutedEventArgs e)
        {
            lstChat.Items.Add("Bot: " +
                bot.GetResponse("start quiz"));
        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            lstChat.Items.Add("Bot: " +
                bot.GetResponse("show tasks"));
        }

        private void btnActivity_Click(object sender, RoutedEventArgs e)
        {
            lstChat.Items.Add("Bot: " +
                bot.GetResponse("show activity log"));
        }
    }
}

//Referencing
//
//Troelsen, A. and Japikse, P., 2022. Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11th ed. New York: Apress.
//Microsoft, 2025. Windows Presentation Foundation (WPF). [online] Available at: < https://learn.microsoft.com/en-us/dotnet/desktop/wpf/> [Accessed 14 May 2026].