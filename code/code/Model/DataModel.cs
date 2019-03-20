using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.Data;

namespace code.Model
{
    public class DataModel : IGetDataAble
    {
        public MockData MockData { get; set; }

        public DataModel()
        {
            MockData = new MockData();
        }

        public List<string> GetData(string path)
        {
            return MockData.GET(path);
        }
    }
}
