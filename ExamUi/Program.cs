using ExamLib.Classes;
using ExamLib.Classes.Questions;
using ExamLib.Classes.Exams;
using ExamLib.Helper;
namespace ExamUi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int examType = Utility.PrintMessageAndGetInt("PLease enter The Type Of Exam (1 For Practical | 2 For Final)");

            switch (examType)
            {
                case 1:
                    Subject cSharp1 = new Subject(1, "Csharp", new Practical());
                    cSharp1.CreateExam();
                    break;
                case 2:
                    Subject cSharp2 = new Subject(1, "Csharp", new Final());
                    cSharp2.CreateExam();
                    break;
                default:
                    Console.WriteLine("Please Enter valid Exam Type Number..");
                    break;
            }



            //string[,] names = { {"ebrahem","ashraf","ahmed" } };
            //Console.WriteLine(names[0,1]);


        }
    }
}
