using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBase
{
    public delegate void MethodCallback(string loacation, List<string> Data);

    public abstract class APIBase
    {
        public Dictionary<string, MethodCallback> MethodDictionary { get; set; }

        public readonly string APIVersion = "1.0"; 

        public abstract void DynamicInsert(string loacation, List<string> Data);

        public APIBase()
        {
            MethodDictionary = new Dictionary<string, MethodCallback>
            {
                { "DynamicInsert", DynamicInsert }
            };
        }
    }
}
