using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWritter
{
    public interface IGetDataAble
    {
        List<string> GETStringData(string datapath); 
    }

    public class Generator : GeneratorBase.APIBase
    {
        public Record.Recorder Speaker { get; private set; }

        public IGetDataAble DataProvider { get; set; }

        public string Path { get; set; }

        public Generator(string path, string RecordPath)
        {
            Path = path;
            Speaker = new Record.Recorder(RecordPath);
            DataProvider = new MockDataBase();

            if (Speaker.Tape.ApiVersion != APIVersion)
            {
                Console.WriteLine("apiVersion not match");
                Speaker = null;
            }
        }

        public void WriteData()
        {
            foreach (var method in Speaker.Tape.MethodCalls)
            {
                MethodDictionary[method.MethodName](method.Params);
            }
        }

        public override void DynamicInsert(GeneratorBase.MethodParams mp)
        {
            List<string> Data = DataProvider.GETStringData(mp.DataPath);
            if (mp.IsInTableCell)
            {
                using (WordprocessingDocument document = WordprocessingDocument.Open(Path, true))
                {
                    var mainPart = document.MainDocumentPart;
                    var bookmarks = from bm in mainPart.Document.Body.Descendants<BookmarkStart>()
                                    where bm.Name == mp.BookMarkName
                                    select bm;
                    var bookmark = bookmarks.SingleOrDefault();
                    if (bookmark != null)
                    {
                        var table = bookmark.Parent.Parent.Parent.Parent;

                        if (table is Table)
                        {
                            while (table.Elements<TableRow>().Count() - mp.TableCellRow.Value < Data.Count)
                            {
                                TableRow rowCopy = (TableRow)table
                                    .Elements<TableRow>().ElementAt(mp.TableCellRow.Value)
                                    .CloneNode(true);
                                rowCopy.RemoveAllChildren<BookmarkStart>();
                                rowCopy.RemoveAllChildren<BookmarkEnd>();

                                foreach (var cell in rowCopy.Elements<TableCell>())
                                {
                                    cell.RemoveAllChildren<Paragraph>();
                                    cell.Append(new Paragraph());
                                }

                                table.Append(rowCopy);
                            }

                            for (int i = 0; i < Data.Count; i++)
                            {
                                var cell = table
                                    .Elements<TableRow>().ElementAt(mp.TableCellRow.Value + i)
                                    .Elements<TableCell>().ElementAt(mp.TableCellColumn.Value);

                                cell.RemoveAllChildren<Paragraph>();
                                Paragraph p = new Paragraph();
                                Run run = p.AppendChild(new Run());
                                run.AppendChild(new Text(Data[i]));
                                cell.Append(p);
                            }
                        }
                    }
                }
            }
        }
    }
}
