using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Record;

namespace code.ViewModel
{
    public class RecordViewModel
    {
        public Recorder Recorder { get; set; }

        public RecordViewModel(string apiVersion, string path = @"../../../Output/tape.xml")
        {
            Recorder = new Recorder(path, apiVersion);
        }

        public void AddRecord(string MethodName, List<Param> Params)
        {
            Recorder.AddMethodCall(new MethodCall {
                                        MethodName = MethodName,
                                        Params = Params}
            );
        }
    }
}
