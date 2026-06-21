using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    public class Chatbot
    {
        Random random = new Random();

        public string UserName = "";
        public string FavouriteTopic = "";
        public string PreviousResponse = "";

        public Dictionary<string, List<string>> TopicResponses = new Dictionary<string, List<string>>();

        public List<CyberTask> Tasks = new List<CyberTask>();

        public List<ActivityLog> Logs = new List<ActivityLog>();

        public List<QuizQuestion> QuizQuestions = new List<QuizQuestion>();


        public Chatbot()
        {
            // Password responses
            TopicResponses.Add("password", new List<string>()
            {
                "Use strong passwords with uppercase and lowercase letters, symbols and numbers.",
                "Never use personal information in your passwords.",
                "Try avoid using the same password for multiple accounts."
            });

            // Phishing responses
            TopicResponses.Add("phishing", new List<string>()
            {
                "Phishing scams try to trick you into giving away personal information.",
                "Phishing is often when scammers pretend to be trusted companies."
            });

            // Privacy responses
            TopicResponses.Add("privacy", new List<string>()
            {
                "Always check your privacy settings online.",
                "To ensure privacy use two-factor authentication.",
                "To ensure privacy avoid sharing sensitive information publicly."
            });

            // Safe browsing responses
            TopicResponses.Add("safe", new List<string>()
            {
                "A safe browsing example is to make sure websites use HTTPS before entering personal information.",
                "An example of safe browsing is when avoid downloading files from unknown websites.",
                "To ensure safe browsing keep your browser updated for better protection."
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "What should you do if an email asks for your password?",
                Answer = "Report"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "Should you reuse passwords on multiple websites? (Yes/No)",
                Answer = "No"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "HTTPS websites are generally safer than HTTP websites. (True/False)",
                Answer = "True"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "What type of attack tricks users into giving personal information?",
                Answer = "Phishing"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "Should you share your passwords with friends? (Yes/No)",
                Answer = "No"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "What security feature requires a second verification step?",
                Answer = "Two-factor authentication"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "Is it safe to click links from unknown senders? (Yes/No)",
                Answer = "No"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "What should you do before downloading a file from a website?",
                Answer = "Verify the website"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "Strong passwords should contain letters, numbers and symbols. (True/False)",
                Answer = "True"
            });

            QuizQuestions.Add(new QuizQuestion()
            {
                Question = "What does the 'S' in HTTPS stand for?",
                Answer = "Secure"
            });

        }

        // Random responce method 
        public string GetRandomResponse(string topic)
        {
            List<string> responses = TopicResponses[topic];

            int number = random.Next(responses.Count);

            return responses[number];
        }

        // Main response method
        public string GetResponse(string message)
        {
            try
            {
                message = message.ToLower();

                string[] words = message.Split(' ');

                // Name
                if (message == "what is my name")
                {
                    return "Your name is " + UserName;
                }

                // If confused response
                if (message == "i'm confused" ||
                    message == "i dont know" ||
                    message == "explain more" ||
                    message ==  "tell me more")
                {
                    if (PreviousResponse != "")
                    {
                        return PreviousResponse;
                    }

                    return "Please ask a cybersecurity topic first.";
                }

                // Keyword finder
                foreach (string topic in TopicResponses.Keys)
                {
                    foreach (string word in words)
                    {
                        if (word == topic)
                        {
                            string botReply = GetRandomResponse(topic);

                            PreviousResponse = botReply;

                            return botReply + " Would you like to ask about anything else?"; 
                        }
                    }
                }

                // Favourite topic
                if (FavouriteTopic == "")
                {
                    FavouriteTopic = message;

                    return "Great! I will remember that your favourite cybersecurity topic is " + FavouriteTopic + " Would you like to ask about anything else?"; ;
                }

                // Unkown input
                return "I'm not sure about that topic. Please ask about passwords, phishing, privacy or safe browsing.";
            }

            catch (Exception)
            {
                return "Something went wrong. Please try again.";
            }
        }
    }
}
