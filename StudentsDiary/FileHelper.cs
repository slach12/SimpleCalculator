
using System.IO;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper<T> where T : new()
    {
        private string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }
        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();
            var serialize = new XmlSerializer(typeof(T));
            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (T)serialize.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }

        public void SerializeToFile(T students)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }

    }
}
