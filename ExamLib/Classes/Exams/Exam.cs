using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Classes.Exams
{
    public abstract class Exam
    {
        public int Time { get; set; }

        public int NumberOfQuestions { get; set; }

        public virtual void DisplayExamInformation() 
        {
            Console.WriteLine($"Time:{Time} - Number oF Questions: {NumberOfQuestions}");
        }
    }
}
