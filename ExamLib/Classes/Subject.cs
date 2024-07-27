using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamLib.Classes.Exams;
using ExamLib.Helper;




namespace ExamLib.Classes
{
    public class Subject
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public Exam Exam { get; set; }

        public Subject(int id, string name, Exam exam)
        {
            Id = id;
            Name = name;
            Exam = exam;
        }

        public void CreateExam()
        {
            if(Exam is Final) 
            {
                Console.WriteLine("Welcome To The Final Exam..");
                Console.WriteLine("----------------------------");

                //Validate duration
                int durationNumber = ExamValidation.DurationValidation();

                int numberOfQuestions = ExamValidation.QuestionNumberValidator();

                Final final = new Final() { Time = durationNumber, NumberOfQuestions = numberOfQuestions };
                final.CreateQuestions();
            }
            else 
            {
                Console.WriteLine("Welcome To The Practical Exam..");
                Console.WriteLine("----------------------------");

                int durationNumber = ExamValidation.DurationValidation();

                int numberOfQuestions = Utility.PrintMessageAndGetInt("Please Enter The Number Of Questions: ");

                Practical practical = new Practical() { Time = durationNumber, NumberOfQuestions = numberOfQuestions };
                practical.CreateQuestions();
            }
        }



    }
}
