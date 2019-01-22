using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    class DataTemplet
    {
        public DataTempletItem Root { get; set; }

        public DataTemplet()
        {
            Root = new DataTempletItem();
        }
    }
}
