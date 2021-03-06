﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.Model;

namespace code.ViewModel
{
    public interface IGenerateDataTempletTreeAble
    {
        //根据实际数据模型建立数据模板树
        void GenerateDataTempletTree(DataTempletItem root);
    }

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

        public IGenerateDataTempletTreeAble DataTempletModel { get; set; }

        public DataTempletViewModel()
        {
            Root = new List<DataTempletItem>
            {
                new DataTempletItem()
            };
            DataTempletModel = new DataTempletModel(@"..\..\Data\DataTempletDemo.xml");

            DataTempletModel.GenerateDataTempletTree(Root[0]);
        }
    }
}
