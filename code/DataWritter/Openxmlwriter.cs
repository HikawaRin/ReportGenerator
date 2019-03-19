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

        public void ShowBookMarks()
        {
            string pattern = @"_.*";
            using (WordprocessingDocument document = WordprocessingDocument.Open(Path, true))
            {
                var mainPart = document.MainDocumentPart;
                var bookmarks = mainPart.Document.Body.Descendants<BookmarkStart>();

                /* 
                for (int i = 0; i < bookmarks.Count(); i++)
                {
                    var bks = bookmarks.ElementAt(i);
                    var next = bks.NextSibling();
                    if (next is BookmarkEnd)
                    {
                        var bme = (BookmarkEnd)next;
                        if (int.Parse(bks.Id) - int.Parse(bme.Id) == 1)
                        {
                            var copy = (BookmarkEnd)next.Clone();
                            bks.Parent.RemoveChild<BookmarkEnd>(bme);
                            bks.Parent.InsertBefore<BookmarkEnd>(copy, bks);
                        }
                    }
                }
                */

                foreach (var b in bookmarks)
                {
                    // 过滤掉underscore bookmarks
                    if (Regex.Matches(b.Name, pattern).Count > 0)
                    {
                        continue ;
                    }
                    Console.WriteLine(b.Name);

                    var table = b.Parent.Parent.Parent.Parent;
                    
                    if (table is Table)
                    {
                        var cell = table.Elements<TableRow>().ElementAt(0).Elements<TableCell>().ElementAt(3);
                        Console.WriteLine(cell.InnerText);
                    }
                }
            }
        }
    }
}
