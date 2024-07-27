using ExamLib.Classes.Answers;
using ExamLib.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Classes.Interfaces
{
    internal interface IQuestion
    {
        void Question();

        Question GetQuestionInfo();

        Answer GetRightAnswer();

        void AddQuestionAndAnswer(Question question, Answer answer);

        //void PrintQuestion();

        //void ValidateAnswers();
    }
}
