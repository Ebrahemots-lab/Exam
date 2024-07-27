using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamLib.Classes.Answers;
using ExamLib.Classes.Interfaces;
using ExamLib.Helper;

namespace ExamLib.Classes.Questions
{
    public class TrueFalse : Question , IQuestion
    {
        public int questNumber;

        Question[] questions ;

        Answer[] rightAnswers;

        Answer[] userAnswers;

        public TrueFalse()
        {
            
        }
        public TrueFalse(int number)

        {
            questNumber = number;
            questions = new Question[number];
            rightAnswers = new Answer[number];
            userAnswers = new Answer[number];
        }

        public void Question()
        {
            
                Question question = GetQuestionInfo();

                Answer rightAnswer = GetRightAnswer();

                AddQuestionAndAnswer(question, rightAnswer);
                
        }

        public Question GetQuestionInfo()
        {

            Console.WriteLine("PLease enter question Body: ");
            string questionBody = Console.ReadLine()!;


            int questionMark = ExamValidation.QuestionMarkValidator();

            return new TrueFalse() { Header = "True-False Question", Body = questionBody, Mark = questionMark };
        }

        public Answer GetRightAnswer()
        {
            int answerId = Utility.PrintMessageAndGetInt("PLeas enter the right Answer Id (1 - True :: 2 - False)");

            string Txt = answerId == 1 ? "True" : "False";
            return new Answer() { Id = answerId, Text = Txt };
        }


        public void AddQuestionAndAnswer(Question question, Answer answer)
        {
            ExamHelper.AddQuestionAndAnswer(questions, question, rightAnswers, answer);
        }

        public void PrintQuestion()
        {
            if(questions[0] is not null) 
            {
                Console.WriteLine(questions[0].Header);

                for (int i = 0; i < questions.Length; i++)
                {

                    if (questions[i] is not null)
                    {
                        Console.WriteLine($"Q{i + 1} -> {questions[i].Body}");

                        GetUserAnswerAndSaveIt(i);
                    }
                }
            }
            else 
            {
                Console.WriteLine("Please come Back later");
            }
        }

        public void GetUserAnswerAndSaveIt(int index) 
        {

            int answerId = Utility.PrintMessageAndGetInt("1 - True \n2 - False");

            string txt = answerId == 1 ? "True" : "False";

            userAnswers[index] = new Answer() { Id = answerId, Text = txt };
        }

        public void DisplayQuestionAndAnswers()
        {
            ExamHelper.DisplayQuestionAndAnswers(userAnswers, rightAnswers, questions,"True-False");
        }

        public int ValidateAndReturnMark()
        {
            //loop through the useranswer and compare it to the Right answers 
            //if it's right answer then add the mark for this question to him
            //else give him 0
            return ExamHelper.ValidAndReturnMark(userAnswers, rightAnswers, questions);
        }

        public int CalculateTotalMarsk() 
        {
            return ExamHelper.CalculateTotalMarks(questions);
        }

    }
}
