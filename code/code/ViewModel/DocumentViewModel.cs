using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace code.ViewModel
{
    public class DocumentViewModel
    {
        public DocumentViewModel()
        {
        }

        public void InsertBookMark(string name)
        {
            Word.Cell c = Globals.ThisAddIn.Application.Selection.Cells[1];
            c.Range.Bookmarks.Add(name);
        }
    }
}
