using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace code.Model
{
    public interface IGetDataAble
    {
        //接受数据路径返回数据
        List<string> GetData(string path);
    }

    public class DocumentModel : GeneratorBase.APIBase
    {
        public Word.Application _application { get; private set; }

        public IGetDataAble DataModel { get; set; }

        public DocumentModel()
        {
            _application = Globals.ThisAddIn.Application;

            DataModel = new DataModel();
        }

        public void AddBookMark(Word.Range range, string name)
        {
            range.Bookmarks.Add(name);
        }

        public override void DynamicInsert(GeneratorBase.MethodParams mp)
        {
            List<string> Data = DataModel.GetData(mp.DataPath);

            if (Data.Count == 0)
            {
                return;
            }

            Word.Bookmark bookmark = null;
            foreach (Word.Bookmark bm in _application.ActiveDocument.Bookmarks)
            {
                if (bm.Name == mp.BookMarkName)
                {
                    bookmark = bm;
                    break;
                }// if (bm.Name == BookMarkName)
            }// foreach (Word.Bookmark bm in _application.ActiveDocument.Bookmarks)
            if (bookmark is null)
            {
                return;
            }// if (bookmark is null)
            else
            {
                if (bookmark.Column)
                {
                    Word.Table table = bookmark.Range.Tables[1];
                    Word.Cell c = bookmark.Range.Cells[1];

                    int distance = Data.Count - table.Rows.Count + c.RowIndex - 1;
                    if (distance > 0)
                    {
                        for (int i = 0; i < distance; i++)
                        {
                            table.Rows.Add();
                        }
                    }
                    int index = 0;
                    int columnindex = c.ColumnIndex;
                    while (c != null)
                    {
                        if (index == Data.Count)
                        {
                            break;
                        }
                        if (c.ColumnIndex == columnindex)
                        {
                            c.Range.Text = Data[index++];
                        }

                        c = c.Next;
                    }// while (c != null)
                }// if (bookmark.Column)
                else
                {
                    for (int i = 0; i < Data.Count; i++)
                    {
                        bookmark.Range.Text += Data[i];
                    }
                }// elif (!bookmark.Column)
            }// elif (bookmark is not null)
        }
    }
}
