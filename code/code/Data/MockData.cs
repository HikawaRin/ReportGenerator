using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Data
{
    public class MockData
    {
        public List<string> Data { get; set; }

        public MockData()
        {
            Data = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Data.Add(i.ToString());
            }
        }

        public List<string> GET(string path)
        {
            return Data;
        }
    }
}
