using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.Model;

namespace code.ViewModel
{
    public class DataTempletItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public DataTempletItem Parent { get; set; }

        public List<DataTempletItem> Children { get; set; }

        public DataTempletItem()
        {
            Name = "";
            Path = "";
            Parent = null;
            Children = new List<DataTempletItem>();
        }
    }

    public class DataTempletViewModel
    {
        public List<DataTempletItem> Root { get; set; }

        public IDataTempletModel DataTempletModel { get; set; }

        public DataTempletViewModel()
        {
            Root = new List<DataTempletItem>
            {
                new DataTempletItem()
            };
            DataTempletModel = new DataTempletModel(@"C:\code\ReportGenerator\code\code\Data\DataTempletDemo.xml");

            DataTempletModel.GenerateDataTempletTree(Root[0]);
        }
    }
}
