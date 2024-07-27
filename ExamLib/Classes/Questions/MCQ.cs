using ExamLib.Classes.Answers;
using ExamLib.Classes.Interfaces;
using ExamLib.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Classes.Questions
{
    public class MCQ : Question, IQuestion
    {
        #region Attributes
        private static int questionNumber;

        private int helperNumber = 0;
        private int helperNumber02 = 0;

        Question[] questions;

        Answer[] rightAnswers;

        string[,] Choices;

        Answer[] userAnswers;

        #endregion

        #region Constructors
        public MCQ()
        {

        }
        public MCQ(int nubmersOfQuestions)
        {
            questionNumber = nubmersOfQuestions;

            questions = new Question[nubmersOfQuestions];

            rightAnswers = new Answer[nubmersOfQuestions];

            Choices = new string[nubmersOfQuestions, 3];

            userAnswers = new Answer[nubmersOfQuestions];
        }
        #endregion

        #region Question Information
        public void Question()
        {

                Question question = GetQuestionInfo();

                GetChoices();

                Answer answer = GetRightAnswer();

                helperNumber02++;

                AddQuestionAndAnswer(question, answer);
        }

        public Question GetQuestionInfo()
        {
            Console.WriteLine("PLease enter Question Body: ");
            string questionBody = Console.ReadLine()!;

            int output = ExamValidation.QuestionMarkValidator();

            return new MCQ() { Header = "MCQ", Body = questionBody, Mark = output };

        }

        public void GetChoices()
        {

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Please Enter Chooice {i + 1}: ");
                string choice = Console.ReadLine()!;
                Choices[helperNumber, i] = choice;

            }

            helperNumber++;
        }

        public Answer GetRightAnswer()
        {
            int rightChoice = ExamValidation.ValidateMcqAnswers("Please enter the right Choice Id: ");

            return new Answer() { Id = rightChoice,Text = Choices[helperNumber02,rightChoice - 1] };
            
        }

        #endregion

        #region Add Question
        public void AddQuestionAndAnswer(Question question, Answer answer)
        {
            ExamHelper.AddQuestionAndAnswer(questions, question,rightAnswers,answer);
        }
        #endregion

        #region Print Question And Choises
        public void PrintQuestion()
        {
            if(questions.Length > 0) 
            {
                Console.WriteLine(questions[0].Header);

                for (int i = 0; i < questions.Length; i++)
                {

                    if (questions[i] != null)
                    {
                        Console.WriteLine($"Q{i + 1} -> {questions[i].Body}");

                        Console.WriteLine("PLease Choose One of theses choises: ");

                        PrintChoices(i);
                    }

                }
            }
            else 
            {
                Console.WriteLine("There is No Question Yet..");
            }
        }

        public void PrintChoices(int row)
        {
            for (int i = row; i < row + 1; i++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.WriteLine($"{z + 1} - {Choices[i, z]}");
                }
            }
            GetUserAnswer(row);
        }
        #endregion

        #region Get Data And Validation
        public void GetUserAnswer(int index)
        {
            int userAnswer = ExamValidation.ValidateMcqAnswers("Please Enter a choice Id: ");

            userAnswers[index] = new Answer() { Id = userAnswer, Text = Choices[index, userAnswer - 1] };
        }

        public int ValidateAndReturnMark()
        {
            return ExamHelper.ValidAndReturnMark(userAnswers,rightAnswers,questions);
        }

        public int CalculateTotalMarsk()
        {
            return ExamHelper.CalculateTotalMarks(questions);
        }

        public void DisplayQuestionAndAnswers()
        {
            ExamHelper.DisplayQuestionAndAnswers(userAnswers,rightAnswers,questions,"MCQ");
        }
        #endregion


    }
}
