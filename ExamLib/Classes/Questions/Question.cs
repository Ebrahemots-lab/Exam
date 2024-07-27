using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib.Classes.Questions
{
    public abstract class Question
    {
        public string? Header { get; set; }

        public string Body { get; set; }

        private int mark;
        public int Mark
        {
            get { return mark; }
            set
            {
                mark = value < 0 ? 1 : value;
            }
        }




    }
}
