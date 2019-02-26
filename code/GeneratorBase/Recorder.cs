using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Record
{
    public class Param
    {
        public string ParamName { get; set; }

        public string ValueType { get; set; }

        public string Value { get; set; }
    }

    public class MethodCall
    {
        public string MethodName { get; set; }

        public List<Param> Params { get; set; }

        public MethodCall()
        {
            MethodName = "";
            Params = new List<Param>();
        }
    }

    public class Tape
    {
        public string ApiVersion { get; set; }

        public List<MethodCall> MethodCalls { get; set; }

        public Tape()
        {
            MethodCalls = new List<MethodCall>();
        }
    }

    public class Recorder
    {
        private Tape Tape { get; set; }

        public string Path { get; set; }

        public Recorder(string path, string apiVersion)
        {
            Path = path;
            _deserialize(Path);
            Tape.ApiVersion = apiVersion;
        }

        public void AddMethodCall(MethodCall methodCall)
        {
            Tape.MethodCalls.Add(methodCall);
        }

        public void Save()
        {
            _serialize(Path);
        }

        private void _serialize(string path)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Tape));

            using (FileStream filestream = File.Create(path))
            {
                writer.Serialize(filestream, Tape);
            }
        }

        private void _deserialize(string path)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Tape));

            using (FileStream filestream = File.Open(path, FileMode.OpenOrCreate))
            {
                try
                {
                    Tape = reader.Deserialize(filestream) as Tape;
                }
                catch
                {
                    Tape = new Tape();
                }
            }
        }
    }
}
