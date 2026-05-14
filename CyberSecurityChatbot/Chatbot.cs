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

        public Dictionary<string, string> SentimentResponses = new Dictionary<string, string>();

        public Chatbot()
        {
            // Passwor responses
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
                "Never click suspicious email links.",
                "Scammers often pretend to be trusted companies."
            });

            // Privacy responses
            TopicResponses.Add("privacy", new List<string>()
            {
                "Always check your privacy settings online.",
                "Use two-factor authentication.",
                "Avoid sharing sensitive information publicly."
            });

            // Safe browsing responses
            TopicResponses.Add("safe", new List<string>()
            {
                "Make sure websites use HTTPS before entering personal information.",
                "Avoid downloading files from unknown websites.",
                "Keep your browser updated for better protection."
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
                    message == "explain more")
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

                            return botReply;
                        }
                    }
                }

                // Favourite topic
                if (FavouriteTopic == "")
                {
                    FavouriteTopic = message;

                    return "Great! I will remember that your favourite cybersecurity topic is " + FavouriteTopic;
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
