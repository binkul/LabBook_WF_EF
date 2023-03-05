using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LabBook_WF_EF.Commons
{
    public static class CommonFunctions
    {

        public static void WriteWindowsData(this List<double> list, string fileName)
        {
            string target = @"\Dane";
            string path = Directory.GetCurrentDirectory() + target;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Concat(path, @"\", fileName, ".xml");
            File.Delete(path);

            var serializer = new XmlSerializer(typeof(List<double>));
            using (var stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, list);
                stream.Flush();
            }
        }

        public static List<double> LoadWindowsData(string fileName)
        {
            List<double> windowsData = new List<double>();
            var serializer = new XmlSerializer(typeof(List<double>));

            string path = Directory.GetCurrentDirectory();
            path = string.Concat(path, @"\Dane\", fileName, ".xml");
            if (!File.Exists(path))
                return windowsData;

            using (var stream = File.OpenRead(path))
            {
                try
                {
                    var list = (List<double>)(serializer.Deserialize(stream));
                    windowsData.Clear();
                    windowsData.AddRange(list);
                    stream.Close();
                }
                catch
                {
                    windowsData = new List<double>();
                }
            }

            return windowsData;
        }
    }
}
