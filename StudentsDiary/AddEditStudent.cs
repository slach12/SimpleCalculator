using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
      //  private string _filePath =
        //      Path.Combine(Environment.CurrentDirectory, "students.txt");

        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);

        private int _studentId;
        private Student _student;


        public AddEditStudent(int id =  0)
        {
            InitializeComponent();
            _studentId = id;
            GetStudentData();
            tbFirstName.Select();
        }

        private void GetStudentData()
        {
            if (_studentId != 0)
            {
                Text = "Edytowanie danych ucznia";
                var students = _fileHelper.DeserializeFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studentId);
                if (_student == null)
                    throw new Exception($"Brak użytkownika o Id {_studentId}");
                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {
            tbId.Text = _student.Id.ToString();
            tbFirstName.Text = _student.FirstName;
            tbLastName.Text = _student.LastName;
            tbMath.Text = _student.Math;
            tbPhysics.Text = _student.Physics;
            tbTechonology.Text = _student.Technology;
            tbPolishLang.Text = _student.PolishLang;
            tbForingLang.Text = _student.ForeignLang;
            rtbComents.Text = _student.Coments;

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {
                AssigneIdToNewStudent(students);
            }

            AddNewStudentToList(students);

          
            _fileHelper.SerializeToFile(students);
            Close();
        }


        private void AddNewStudentToList(List<Student> students)
        {
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
        }
        private void AssigneIdToNewStudent(List<Student> students)
        {
            var studentWithHaighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();
            _studentId = studentWithHaighestId == null ? 1 : studentWithHaighestId.Id + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
