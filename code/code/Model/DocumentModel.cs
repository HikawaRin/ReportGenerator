using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace code.Model
{
    public class DocumentModel
    {
        public Word.Application _application { get; private set; }

        public DocumentModel()
        {
            _application = Globals.ThisAddIn.Application;
        }

        public void AddBookMark(Word.Range range, string name)
        {
            range.Bookmarks.Add(name);
        }
    }
}
