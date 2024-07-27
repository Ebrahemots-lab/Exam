using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Helper
{
    public static class Utility
    {
        public static int PrintMessageAndGetInt(string message) 
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine()!;
            bool isValidInput = int.TryParse(userInput, out int output);

            return output;
        }

        public static void DisplayFinalMarks(int totalMarks,int userMarks,TimeSpan time) 
        {
            Console.WriteLine();
            Console.WriteLine($"Time Taken : {time}");
            Console.WriteLine($"Your Marks: {userMarks} From {totalMarks}");
            Console.WriteLine("Thank You.");
        }
    }
}
