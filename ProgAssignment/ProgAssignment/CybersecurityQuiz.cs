using CyberSecurityBotApp.Models;

public class CybersecurityQuiz
{
    private List<QuizQuestion> questions = new List<QuizQuestion>();
    private int currentQuestionIndex = 0;
    private int score = 0;

    public CybersecurityQuiz()
    {
        InitializeQuestions();
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0; // Reset question index
        score = 0; // Reset score

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine("CYBERSECURITY QUIZ");
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.ResetColor();
        Console.WriteLine("\nAnswer the following questions about cybersecurity. Type the letter of your answer or 'exit' to quit.\n");

        while (currentQuestionIndex < questions.Count)
        {
            AskQuestion();
        }

        ShowFinalResults();
    }
    private void InitializeQuestions()
    {
        questions.Add(new QuizQuestion(
            "What should you do if you receive an email asking for your password?",
            new List<string>
            {
            "A) Reply with your password",
            "B) Delete the email",
            "C) Report the email as phishing",
            "D) Ignore it"
            },
            2, // Correct answer index (C)
            "Correct! Reporting phishing emails helps prevent scams."
        ));

        questions.Add(new QuizQuestion(
            "Which of the following is NOT a sign of a strong password?",
            new List<string>
            {
            "A) Contains at least 12 characters",
            "B) Includes numbers and symbols",
            "C) Uses common words or phrases",
            "D) Is unique to each account"
            },
            2, // Correct answer index (C)
            "Correct! Strong passwords should avoid common words or phrases."
        ));

        questions.Add(new QuizQuestion(
            "What does VPN stand for?",
            new List<string>
            {
            "A) Virtual Personal Network",
            "B) Virtual Private Network",
            "C) Very Protected Network",
            "D) Virus Prevention Network"
            },
            1, // Correct answer index (B)
            "Correct! VPN stands for Virtual Private Network."
        ));

        questions.Add(new QuizQuestion(
            "Which of the following is a common phishing tactic?",
            new List<string>
            {
            "A) Offering a legitimate discount",
            "B) Creating a sense of urgency",
            "C) Providing helpful information",
            "D) Asking for a donation to charity"
            },
            1, // Correct answer index (B)
            "Correct! Phishing attacks often create urgency to prompt quick actions without careful thought."
        ));

        questions.Add(new QuizQuestion(
            "What is the primary purpose of two-factor authentication?",
            new List<string>
            {
            "A) To make logging in faster",
            "B) To add an extra layer of security",
            "C) To replace passwords",
            "D) To track user activity"
            },
            1, // Correct answer index (B)
            "Correct! Two-factor authentication adds an extra layer of security beyond just a password."
        ));

        questions.Add(new QuizQuestion(
            "Which of these is NOT a type of malware?",
            new List<string>
            {
            "A) Virus",
            "B) Worm",
            "C) Firewall",
            "D) Trojan"
            },
            2, // Correct answer index (C)
            "Correct! Firewall is a security measure, not a type of malware."
        ));

        questions.Add(new QuizQuestion(
            "What should you do to protect your smartphone from security threats?",
            new List<string>
            {
            "A) Use a strong PIN/pattern",
            "B) Enable remote wipe",
            "C) Install apps from unknown sources",
            "D) Both A and B"
            },
            3, // Correct answer index (D)
            "Correct! Using a strong PIN/pattern and enabling remote wipe are both important smartphone security measures."
        ));

        questions.Add(new QuizQuestion(
            "What is the main purpose of a firewall?",
            new List<string>
            {
            "A) To store data",
            "B) To monitor and filter network traffic",
            "C) To speed up internet connections",
            "D) To create backups"
            },
            1, // Correct answer index (B)
            "Correct! A firewall monitors and filters network traffic to prevent unauthorized access."
        ));

        questions.Add(new QuizQuestion(
            "Which of the following is a good practice for public Wi-Fi security?",
            new List<string>
            {
            "A) Access sensitive accounts",
            "B) Use a VPN",
            "C) Disable the firewall",
            "D) Share your screen"
            },
            1, // Correct answer index (B)
            "Correct! Using a VPN encrypts your traffic and protects your data on public Wi-Fi."
        ));

        questions.Add(new QuizQuestion(
            "What does SSL stand for?",
            new List<string>
            {
            "A) Secure Socket Layer",
            "B) System Security Layer",
            "C) Super Strong Lock",
            "D) Safety Shield Layer"
            },
            0, // Correct answer index (A)
            "Correct! SSL stands for Secure Socket Layer, though it's largely been replaced by TLS (Transport Layer Security)."
        ));
    }
    private void AskQuestion()
    {
        var question = questions[currentQuestionIndex];
        Console.WriteLine($"\nQuestion {currentQuestionIndex + 1}: {question.Text}\n");

        for (int i = 0; i < question.Options.Count; i++)
        {
            Console.WriteLine(question.Options[i]);
        }

        Console.Write("\nYour answer: ");
        string userInput = Console.ReadLine().Trim().ToLower();

        if (userInput == "exit")
        {
            ShowFinalResults();
            return;
        }

        if (IsValidAnswer(userInput))
        {
            int answerIndex = Convert.ToInt32(userInput[0]) - 97; // Convert 'a' to 0, 'b' to 1, etc.
            if (answerIndex == question.CorrectAnswerIndex)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{question.Feedback}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nIncorrect. {question.Feedback}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid answer. Please enter A, B, C, or D.");
            Console.ResetColor();
            AskQuestion(); // Retry the same question
            return;
        }

        currentQuestionIndex++;
    }

    private bool IsValidAnswer(string input)
    {
        return input.Length == 1 && "abcd".Contains(input);
    }

    private void ShowFinalResults()
    {
        Console.WriteLine($"\nQuiz exited! Your score: {score} out of {questions.Count}");

        string feedback = score >= questions.Count * 0.8 ? "Great job! You're a cybersecurity pro!" :
                           score >= questions.Count * 0.6 ? "Good work! You have a solid understanding of cybersecurity." :
                           score >= questions.Count * 0.4 ? "Not bad! Keep learning to improve your cybersecurity knowledge." :
                           "Keep learning to stay safe online!";

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n{feedback}");
        Console.ResetColor();

        Console.WriteLine("\nReturning to the chatbot...");
        Console.ReadKey();
    }
}