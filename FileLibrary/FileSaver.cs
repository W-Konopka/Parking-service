using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace FileLibrary
{
    public class FileSaver
    {
        public static void SaveFileToXml<T>(List<T> list, string name)
        {

            Stream stream = File.Create(Environment.CurrentDirectory + name);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(stream, list);
            stream.Close();


        }
        public static List<T> ReadFromXml<T>(string name)
        {
            List<T> list = new List<T>();
            if (File.Exists(name))
            {
                string path = Path.Combine(Environment.CurrentDirectory, name);
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (FileStream stream = File.Open(path, FileMode.Open))
                {
                    list = (List<T>)serializer.Deserialize(stream);
                }
                return list;
            }
            return list;

        }

    }
}