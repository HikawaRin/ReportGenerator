using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataWritter
{
    public class Openxmlwriter
    {
        public string Path { get; set; }

        public Openxmlwriter(string path)
        {
            Path = path;
        }

        public void ShowTableIndex()
        {
            using (WordprocessingDocument document = WordprocessingDocument.Open(Path, true))
            {
                var mainPart = document.MainDocumentPart;
                var table = mainPart.Document.Body.Descendants<Table>().First();

                Console.WriteLine("rows:{0}", table.Descendants<TableRow>().Count());
                foreach (var row in table.Descendants<TableRow>())
                {
                    Console.WriteLine("column:{0}", row.Descendants<TableCell>().Count());
                }
            }
        }

        public void ShowBookMarks()
        {
            string pattern = @"_.*";
            using (WordprocessingDocument document = WordprocessingDocument.Open(Path, true))
            {
                var mainPart = document.MainDocumentPart;
                var bookmarks = mainPart.Document.Body.Descendants<BookmarkStart>();

                foreach (var b in bookmarks)
                {
                    // 过滤掉underscore bookmarks
                    if (Regex.Matches(b.Name, pattern).Count > 0)
                    {
                        continue ;
                    }
                    // Console.WriteLine(b.Name);

                    var table = b.Parent.Parent.Parent.Parent;
                    
                    if (table is Table)
                    {
                        var cell = table.Elements<TableRow>().ElementAt(2).Elements<TableCell>().ElementAt(2);
                        Console.WriteLine(cell.InnerText);
                        // Find the first paragraph in the table cell.
                        Paragraph p = cell.Elements<Paragraph>().First();

                        Run run = p.AppendChild(new Run());
                        run.AppendChild(new Text(b.Name));
                        /*
                        // Find the first run in the paragraph.
                        Run r = p.Elements<Run>().First();

                        // Set the text for the run.
                        Text t = r.Elements<Text>().First();
                        t.Text = b.Name;
                        */
                    }
                }
            }
        }
    }
}
