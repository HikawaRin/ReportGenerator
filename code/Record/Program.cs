using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorBase;

namespace Record
{
    class Program
    {
        static void Main(string[] args)
        {
            Recorder recorder = new Recorder(@"../../tape.xml", "1.0");

            recorder.AddMethodCall(new MethodCall {
                MethodName = "测试函数", 
                Params = { new Param {
                    ParamName = "测试参数",
                    ValueType = "int", 
                    Value = "44"
                } }
            });

            recorder.Save();
        }
    }
}
