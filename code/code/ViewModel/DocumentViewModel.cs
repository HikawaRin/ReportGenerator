using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.Model;
using Word = Microsoft.Office.Interop.Word;

namespace code.ViewModel
{
    public interface IGetDataAble
    {
        //接受数据路径返回数据
        List<string> GetData(string  path);
    }

    public class DocumentViewModel
    {
        public DocumentModel DocumentModel { get; set; }

        public IGetDataAble DataModel { get; set; }

        public DocumentViewModel()
        {
            DocumentModel = new DocumentModel();
            DataModel = new DataModel();
        }

        public void InsertBookMark(string name)
        {
            try
            {
                Word.Cell c = Globals.ThisAddIn.Application.Selection.Cells[1];
                DocumentModel.AddBookMark(c.Range, name);
            }
            catch(Exception)
            {
                DocumentModel.AddBookMark(Globals.ThisAddIn.Application.Selection.Range, name);
            }
        }

        public void InsertListData(string BookMarkName, string DataPath)
        {
            DocumentModel.DynamicInsert(BookMarkName, DataModel.GetData(DataPath));
        }
    }
}
