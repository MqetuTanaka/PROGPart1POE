using System.Collections.Generic;

namespace ProgPOEP3
{
    public static class QuizData
    {
        public static List<QuizQuestion> GetQuestions()
        {
            var questions = new List<QuizQuestion>();

            questions.Add(new QuizQuestion(
                "What should you do if you receive an email asking for your password?",
                new List<string>
                {
                    "A) Reply with your password",
                    "B) Delete the email",
                    "C) Report the email as phishing",
                    "D) Ignore it"
                },
                2,
                "✅ Correct! Reporting phishing emails helps prevent scams from affecting others too."));

            questions.Add(new QuizQuestion(
                "Which of the following is NOT a sign of a strong password?",
                new List<string>
                {
                    "A) Contains at least 12 characters",
                    "B) Includes numbers and symbols",
                    "C) Uses common words or phrases",
                    "D) Is unique to each account"
                },
                2,
                "✅ Correct! Avoid using common words or phrases—they’re easy to guess."));

            questions.Add(new QuizQuestion(
                "What does VPN stand for?",
                new List<string>
                {
                    "A) Virtual Personal Network",
                    "B) Virtual Private Network",
                    "C) Very Protected Network",
                    "D) Virus Prevention Network"
                },
                1,
                "✅ That's right! VPN means Virtual Private Network—it helps secure your internet connection."));

            questions.Add(new QuizQuestion(
                "Which of the following is a common phishing tactic?",
                new List<string>
                {
                    "A) Offering a legitimate discount",
                    "B) Creating a sense of urgency",
                    "C) Providing helpful information",
                    "D) Asking for a donation to charity"
                },
                1,
                "🎯 Correct! Scammers often try to rush you into bad decisions by creating urgency."));

            questions.Add(new QuizQuestion(
                "What is the primary purpose of two-factor authentication?",
                new List<string>
                {
                    "A) To make logging in faster",
                    "B) To add an extra layer of security",
                    "C) To replace passwords",
                    "D) To track user activity"
                },
                1,
                "🔐 Correct! 2FA adds extra protection—even if someone steals your password."));

            questions.Add(new QuizQuestion(
                "Which of these is a good way to protect your online privacy?",
                new List<string>
                {
                    "A) Use public Wi-Fi without a VPN",
                    "B) Share your passwords with friends",
                    "C) Use unique passwords and adjust privacy settings",
                    "D) Accept all cookies without reading"
                },
                2,
                "🔒 Correct! Using unique passwords and managing your settings boosts privacy."));

            questions.Add(new QuizQuestion(
                "How often should you update your software and apps?",
                new List<string>
                {
                    "A) Only when they stop working",
                    "B) Rarely, to avoid issues",
                    "C) As soon as updates are available",
                    "D) Never, if it's working fine"
                },
                2,
                "⚙️ Correct! Updates often patch security holes—install them regularly!"));

            questions.Add(new QuizQuestion(
                "What is the best way to handle suspicious attachments in an email?",
                new List<string>
                {
                    "A) Open them to see what's inside",
                    "B) Forward them to your friends",
                    "C) Scan them with antivirus before opening",
                    "D) Delete the email without opening the attachment"
                },
                3,
                "🦠 Correct! Suspicious attachments can carry malware—delete or scan them first."));

            questions.Add(new QuizQuestion(
                "What is social engineering in cybersecurity?",
                new List<string>
                {
                    "A) Using software to hack systems",
                    "B) Manipulating people into giving up confidential information",
                    "C) A method of encrypting data",
                    "D) A type of firewall"
                },
                1,
                "🧠 Correct! Social engineering tricks people into revealing sensitive info."));

            questions.Add(new QuizQuestion(
                "Which practice helps protect your identity online?",
                new List<string>
                {
                    "A) Posting personal info on social media",
                    "B) Using the same password everywhere",
                    "C) Using strong, unique passwords and enabling 2FA",
                    "D) Connecting to unknown Wi-Fi networks"
                },
                2,
                "🕵️ Correct! Strong, unique passwords + 2FA = strong identity protection."));

            return questions;
        }
    }
}
