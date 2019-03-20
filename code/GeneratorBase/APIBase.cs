using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBase
{
    public class MethodParams
    {
        public string BookMarkName { get; set; }

        public bool IsInTableCell { get; set; }

        public int? TableCellRow { get; set; }

        public int? TableCellColumn { get; set; }

        public string DataPath { get; set; }

        public MethodParams()
        {
            BookMarkName = "";
            IsInTableCell = false;
            TableCellRow = null;
            TableCellColumn = null;
            DataPath = "";
        }

        public MethodParams(string bookMarkName, string dataPath, bool isInTableCell, int? tableCellRow, int? tableCellColumn)
        {
            BookMarkName = bookMarkName;
            IsInTableCell = isInTableCell;
            TableCellRow = tableCellRow;
            TableCellColumn = tableCellColumn;
            DataPath = dataPath;
        }
    }

    public delegate void MethodCallback(MethodParams mp);

    public abstract class APIBase
    {
        public Dictionary<string, MethodCallback> MethodDictionary { get; set; }

        public readonly string APIVersion = "1.0"; 

        public abstract void DynamicInsert(MethodParams mp);

        public APIBase()
        {
            MethodDictionary = new Dictionary<string, MethodCallback>
            {
                { "DynamicInsert", DynamicInsert }
            };
        }
    }
}
