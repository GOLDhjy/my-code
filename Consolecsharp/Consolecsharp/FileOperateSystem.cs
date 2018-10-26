using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Consolecsharp
{
    public static class FileOperateSystem
    {
        public static void WriteXmlAsync(string Path, log ObjectXml)
        {
            try
            {
                using (FileStream FS = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    XmlSerializer MyXmlSerializer = new XmlSerializer(typeof(log));
                    MyXmlSerializer.Serialize(FS, ObjectXml);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadXmlAsync(string Path,out log Result)
        {
            using (FileStream FS = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer MyXmlSerializer = new XmlSerializer(typeof(log));
                Result = (log)MyXmlSerializer.Deserialize(FS);
            }
        }
    }
}
