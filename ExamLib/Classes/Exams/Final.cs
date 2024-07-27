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
    public class Final : Exam
    {
        public override void DisplayExamInformation()
        {
            Console.WriteLine($"Time: {Time} - Number Of Questions: {NumberOfQuestions}"); ;
        }

        public void CreateQuestions()
        {
            int counter = NumberOfQuestions;
            MCQ mcqQuestion = new MCQ(NumberOfQuestions);
            TrueFalse tfQuestion = new TrueFalse(NumberOfQuestions);

            while (counter > 0)
            {

                int typeId = Utility.PrintMessageAndGetInt("PLease enter Type Of Question (1 For MCQ | 2 For True - False)");

                if (typeId == 1)
                {
                    
                    mcqQuestion.Question();


                }
                else if (typeId == 2)
                {
                    
                    tfQuestion.Question();
                }

                counter--;
            }


            Console.WriteLine("Wanna Start The Exam: Y|N");

            string startExamChoice = Console.ReadLine()!.ToLower();

            if(startExamChoice == "Y".ToLower()) 
            {
                Console.Clear();
                //tfQmcqQuestionuestion.PrintQuestion();

                //get Questions and Answer from MCQ and there marks 
                //get questions and Answer from True-False and there marks
                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                mcqQuestion.PrintQuestion();

                int mcqMarks = mcqQuestion.ValidateAndReturnMark();

                Console.WriteLine("===============================");

                tfQuestion.PrintQuestion();

                int trqMarks = tfQuestion.ValidateAndReturnMark();

                mcqQuestion.DisplayQuestionAndAnswers();

                tfQuestion.DisplayQuestionAndAnswers();


                int totalMarks = mcqQuestion.CalculateTotalMarsk() + tfQuestion.CalculateTotalMarsk();
                int reulst = mcqMarks + trqMarks;

                stopWatch.Stop();
                TimeSpan elapsed = stopWatch.Elapsed;


                Utility.DisplayFinalMarks(totalMarks, reulst, elapsed);


            }
            else 
            {
                Console.WriteLine("OKi See You SOON..");
            }

        }
    }
}
