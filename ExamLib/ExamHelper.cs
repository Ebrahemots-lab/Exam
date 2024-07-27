using ExamLib.Classes.Answers;
using ExamLib.Classes.Interfaces;
using ExamLib.Classes.Questions;
using ExamLib.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib
{
    public static class ExamHelper
    {

    
      
        public static int ValidAndReturnMark(Answer[] userAnswers, Answer[] rightAnswers, Question[] questions)
        {
            int totalResult = 0;

            for (int i = 0; i < userAnswers.Length; i++)
            {
                if (userAnswers[i] != null)
                {
                    if (userAnswers[i].Text == rightAnswers[i].Text)
                    {
                        totalResult += questions[i].Mark;
                    }
                }
            }

            return totalResult;
        }

        public static int CalculateTotalMarks(Question[] questions)
        {
            int result = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] is not null)
                {
                    result += questions[i].Mark;
                }
            }

            return result;
        }

        public static void DisplayQuestionAndAnswers(Answer[] userAnswers, Answer[] rightAnswers, Question[] questions, string type)
        {
            Console.WriteLine();

            Console.WriteLine($"Questions And Answer In {type}..");
            for (int i = 0; i < questions?.Length; i++)
            {

                if (questions[i] is not null)
                {
                    Console.WriteLine($"Question: {questions[i].Body}");
                    Console.WriteLine($"Right Answer: {rightAnswers[i].Text}");
                    Console.WriteLine($"Your Answer Answer: {userAnswers[i].Text}");
                }
            }
            Console.WriteLine();
        }

        public static void AddQuestionAndAnswer(Question[] questions, Question question, Answer[] rightAnswers, Answer answer)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] == null)
                {
                    questions[i] = question;
                    break;
                }
            }

            for (int i = 0; i < rightAnswers.Length; i++)
            {
                if (rightAnswers[i] == null)
                {
                    rightAnswers[i] = answer;
                    break;
                }
            }
        }
    }
}
