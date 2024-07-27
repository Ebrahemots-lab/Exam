using ExamLib.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib
{
    public static class ExamValidation
    {
        public static int DurationValidation()
        {
            int durationNumber;
            do
            {
                durationNumber = Utility.PrintMessageAndGetInt("PLease enter time For exam from (30 min : 180 min)");
            } while (durationNumber < 30 || durationNumber > 180);
            return durationNumber;

        }

        public static int QuestionNumberValidator()
        {
            int numberOfQuestions;
            do
            {

                numberOfQuestions = Utility.PrintMessageAndGetInt("Please Enter The Number Of Questions: ");

            } while (numberOfQuestions <= 0);

            return numberOfQuestions;

        }

        public static int ValidateMcqAnswers(string message)
        {
            int userAnswer;
            do
            {
              userAnswer = Utility.PrintMessageAndGetInt(message);
            } while (userAnswer < 1 || userAnswer > 3);

            return userAnswer;
        }


        public static int QuestionMarkValidator() 
        {
            int output;
            do
            {
                Console.WriteLine("PLease enter Question Mark: ");
                string questionMark = Console.ReadLine()!;
                bool isValidMark = int.TryParse(questionMark, out output);
            } while (output < 0);

            return output;
        }


    }
}
