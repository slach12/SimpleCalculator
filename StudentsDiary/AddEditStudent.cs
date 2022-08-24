using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
        private string _filePath =
              Path.Combine(Environment.CurrentDirectory, "students.txt");

        private int _studentId;

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
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }
        public AddEditStudent(int id =  0)
        {
            InitializeComponent();
            _studentId = id;
            if (id != 0)
            {
                var students = DeserializeFromFile();
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                    throw new Exception($"Brak użytkownika o Id {id}");
                tbId.Text = student.Id.ToString();
                tbFirstName.Text = student.FirstName;
                tbLastName.Text = student.LastName;
                tbMath.Text = student.Math;
                tbPhysics.Text = student.Physics;
                tbTechonology.Text = student.Technology;
                tbPolishLang.Text = student.PolishLang;
                tbForingLang.Text = student.ForeignLang;
                rtbComents.Text = student.Coments;
            }
            tbFirstName.Select();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();

            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {
                var studentWithHaighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();
                //var studentId = 0;
                //if (studentWithHaighestId == null)
                //{
                //    studentId++;
                //}
                //else
                //{
                //    studentId = studentWithHaighestId.Id + 1;
                //}
                _studentId = studentWithHaighestId == null ? 1 : studentWithHaighestId.Id + 1;
            }


            var student = new Student
            {
                Id = _studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Math = tbMath.Text,
                Technology = tbTechonology.Text,
                Physics = tbPhysics.Text,
                PolishLang = tbPolishLang.Text,
                ForeignLang = tbForingLang.Text,
                Coments = rtbComents.Text

            };

            students.Add(student);
            SerializeToFile(students);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
