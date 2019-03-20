using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataWritter.Openxmlwriter Writer = new DataWritter.Openxmlwriter(@"../../template.docx");
            // Writer.ShowBookMarks();
            // Writer.ShowTableIndex();
            DataWritter.Generator Generator 
                = new DataWritter.Generator(@"..\\..\\..\\Input\\Template.docx", 
                                            @"..\\..\\..\\Input\\tape.xml");
            Generator.WriteData();
            Console.ReadLine();
        }
    }
}
