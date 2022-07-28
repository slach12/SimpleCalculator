using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private string _filePath =
               Path.Combine(Environment.CurrentDirectory, "students.txt");

    //    private string _filePath = $@"{Environment.CurrentDirectory}\students.txt";


        public Main()
        {
            InitializeComponent();

          //  var students = new List<Student>();
            //students.Add(new Student { FirstName = "Jan" });
            //students.Add(new Student() { FirstName = "Marek" });
            //students.Add(new Student { FirstName = "Małgosia" });
            //SerializeToFile(students);

            var students = DeserializeFromFile();
            foreach(var student in students)
            {
                MessageBox.Show(student.FirstName);
            }
        }



        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();
            var serialize = new XmlSerializer(typeof(List<Student>));
            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serialize.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }

        public void SerializeToFile(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using(var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }
       
        public void SerializeToFileWithTryFinally(List<Student> students)
        {
            var serialize = new XmlSerializer(typeof(List<Student>));
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(_filePath);
                serialize.Serialize(streamWriter, students);
                streamWriter.Close();
                
            }
            finally
            {
                streamWriter.Dispose();
            }
        }



        public void SerializeToFileWithUsing(List<Student> students)
        {
            var serialize = new XmlSerializer(typeof(List<Student>));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serialize.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }


        public void SerializeToFile2(List<Student> students)
        {
            StreamWriter streamWriter = null;
            var serializer = new XmlSerializer(typeof(List<Student>));
            try
            {
                streamWriter = new StreamWriter(_filePath);
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
            finally
            {
                streamWriter.Dispose();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
