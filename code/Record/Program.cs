using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorBase;

namespace Record
{
    class Program
    {
        static void Main(string[] args)
        {
            DataWritter.Openxmlwriter Writer = new DataWritter.Openxmlwriter(@"../../template.docx");
            Writer.ShowBookMarks();

            Console.ReadLine();
        }
    }
}
