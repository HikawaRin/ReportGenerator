using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace code.Data
{
    public class MockData
    {
        private XmlDocument _document { get; set; }

        public MockData()
        {
            _document = new XmlDocument();
            // _document.Load(@"..\..\Data\DataDemo.xml");            
        }

        public List<string> GET(string path)
        {
            List<string> Data = new List<string>();

            XmlNode node = _document.SelectSingleNode(path);
            if (node.HasChildNodes)
            {
                if (node.ChildNodes[0].NodeType == XmlNodeType.Element)
                {
                    foreach (XmlNode n in node.ChildNodes)
                    {
                        Data.Add(n.ChildNodes[0].InnerText);
                    }
                }
                else
                {
                    Data.Add(node.ChildNodes[0].InnerText);
                }
            }

            return Data;
        }
    }
}
