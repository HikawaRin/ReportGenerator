using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.Model;
using Word = Microsoft.Office.Interop.Word;

namespace code.ViewModel
{
    public class DocumentViewModel
    {
        public DocumentModel DocumentModel { get; set; }

        // public IGetDataAble DataModel { get; set; }

        public DocumentViewModel()
        {
            DocumentModel = new DocumentModel();
            // DataModel = new DataModel();
        }

        public void InsertBookMarks(string bookMarkHeader)
        {
            var cells = Globals.ThisAddIn.Application.Selection.Cells;
            for (int i = 1; i <= cells.Count; i++)
            {
                string name = bookMarkHeader + "_" + i.ToString();
                DocumentModel.AddBookMark(cells[i].Range, name);
                cells[i].Range.Text = cells[i].RowIndex.ToString() + "," + cells[i].ColumnIndex.ToString();
            }
        }

        public void InsertBookMark(string name, ref int? row, ref int? column)
        {
            try
            {
                Word.Cell c = Globals.ThisAddIn.Application.Selection.Cells[1];
                DocumentModel.AddBookMark(c.Range, name);

                row = c.RowIndex;
                column = c.ColumnIndex;
            }
            catch(Exception)
            {
                DocumentModel.AddBookMark(Globals.ThisAddIn.Application.Selection.Range, name);
            }
        }

        public void CallMethod(string MethodName, GeneratorBase.MethodParams mp)
        {
            // DocumentModel.DynamicInsert(BookMarkName, DataModel.GetData(DataPath));
            DocumentModel.MethodDictionary[MethodName](mp);
        }

        public void SaveAs(string path)
        {
            Globals.ThisAddIn.Application.ActiveDocument.SaveAs2(path);
        }
    }
}
