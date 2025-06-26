using System.Collections.Generic;

namespace ProgPOEP3
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Feedback { get; set; }

        public QuizQuestion(string question, List<string> options, int correctIndex, string feedback)
        {
            Question = question;
            Options = options;
            CorrectIndex = correctIndex;
            Feedback = feedback;
        }
    }
}
