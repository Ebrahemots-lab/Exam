using ExamLib.Classes.Interfaces;
using ExamLib.Classes.Questions;
using ExamLib.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Classes.Exams
{
    public class Practical : Exam
    {
        public override void DisplayExamInformation()
        {
            Console.WriteLine($"Time: {Time} - Number Of Questions: {NumberOfQuestions}"); ;
        }

        public void CreateQuestions()
        {

            MCQ mcqQuestion = new MCQ(NumberOfQuestions);
            int counter = NumberOfQuestions;
            while (counter > 0)
            {

                mcqQuestion.Question();

                counter--;
            }

            Console.WriteLine("Wanna Start The Exam: Y|N");

            string startExamChoice = Console.ReadLine()!.ToLower();

            if (startExamChoice == "Y".ToLower())
            {

                //start the watch 
                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                mcqQuestion.PrintQuestion();

                int mcqMarks = mcqQuestion.ValidateAndReturnMark();

                int totalMarks = mcqQuestion.CalculateTotalMarsk();


                stopWatch.Stop();

                TimeSpan elapsed = stopWatch.Elapsed;

                Console.Clear();

                mcqQuestion.DisplayQuestionAndAnswers();

                Utility.DisplayFinalMarks(totalMarks, mcqMarks, elapsed);

            }
            else
            {
                Console.WriteLine("OKi See You SOON..");
            }

        }
    }
}
