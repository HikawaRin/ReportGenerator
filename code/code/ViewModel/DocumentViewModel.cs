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

        public DocumentViewModel()
        {
            DocumentModel = new DocumentModel();
        }

        public void InsertBookMark(string name)
        {
            Word.Cell c = Globals.ThisAddIn.Application.Selection.Cells[1];
            DocumentModel.AddBookMark(c.Range, name);
        }
    }
}
