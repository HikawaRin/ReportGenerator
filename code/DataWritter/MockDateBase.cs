using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataWritter
{
    public class MockDataBase : IGetDataAble
    {
        private XmlDocument _document { get; set; }

        public MockDataBase()
        {
            _document = new XmlDocument();
            _document.Load(@"..\..\Data\DataDemo.xml");
        }

        public List<string> GETStringData(string datapath)
        {
            List<string> Data = new List<string>();

            XmlNode node = _document.SelectSingleNode(datapath);
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
