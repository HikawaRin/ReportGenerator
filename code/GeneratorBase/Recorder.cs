using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GeneratorBase;

namespace Record
{
    public class MethodCall
    {
        public MethodName MethodName { get; set; }

        public MethodParams Params { get; set; }

        public MethodCall()
        {
            Params = null;
        }

        public MethodCall(MethodName methodName, MethodParams mp)
        {
            MethodName = methodName;
            Params = mp;
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
        public Tape Tape { get; private set; }

        public string Path { get; set; }

        public Recorder(string path, string apiVersion)
        {
            Path = path;
            // _deserialize(Path);
            Tape = new Tape
            {
                ApiVersion = apiVersion
            };
        }

        public Recorder(string path)
        {
            Path = path;
            _deserialize(Path);
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
