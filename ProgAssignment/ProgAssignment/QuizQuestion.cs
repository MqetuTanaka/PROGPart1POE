using System;
using System.Collections.Generic;

namespace CyberSecurityBotApp.Models
{
    public class QuizQuestion
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Feedback { get; set; }

        public QuizQuestion(string text, List<string> options, int correctAnswerIndex, string feedback)
        {
            Text = text;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
            Feedback = feedback;
        }
    }
}