using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using code.ViewModel;

namespace code.Model
{
    public class DataTempletModel : IGenerateDataTempletTreeAble
    {
        public XmlDocument Document { get; set; }

        public DataTempletModel(string path)
        {
            Document = new XmlDocument();

            //忽略XML中的注释及空白
            XmlReaderSettings Settings = new XmlReaderSettings
            {
                IgnoreComments = true,
                IgnoreWhitespace = true
            };
            using (XmlReader reader = XmlReader.Create(path,  Settings))
            {
                Document.Load(reader);
            }// using (XmlReader reader = XmlReader.Create(path,  Settings))
        }

        #region 构建数据模板树
        public void GenerateDataTempletTree(DataTempletItem root)
        {
            var XmlRoot = Document.DocumentElement;
            root.Name = XmlRoot.Name;
            root.Path = root.Name;

            readXmlChildren(XmlRoot, root);
        }

        private void readXmlChildren(XmlNode xmlparent, DataTempletItem dataparent)
        {
            if (xmlparent.HasChildNodes)
            {
                foreach (XmlNode child in  xmlparent.ChildNodes)
                {
                    if(child.NodeType == XmlNodeType.Element)
                    {
                        DataTempletItem item = new DataTempletItem
                        {
                            Name = child.Name,
                            Path = dataparent.Path + @"/" + child.Name,
                            Parent = dataparent
                        };
                        dataparent.Children.Add(item);

                        readXmlChildren(child, item);
                    }// if(child.NodeType == XmlNodeType.Element)
                }// foreach (XmlNode child in  xmlparent.ChildNodes)
            }// if (xmlparent.HasChildNodes)
        }
        #endregion
    }
}
