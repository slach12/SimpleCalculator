using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace StudentsDiary
{
    public partial class Main : Form
    {

        private delegate void DisplayMessage(string message);

        // private string _filePath =
        //        Path.Combine(Environment.CurrentDirectory, "students.txt");
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);
        //    private string _filePath = $@"{Environment.CurrentDirectory}\students.txt";
        private const byte hId          = 0;
        private const byte hFirstName   = 1;
        private const byte hLastName    = 2; 
        private const byte hComents     = 3;
        private const byte hMath        = 4;
        private const byte hTechnology  = 5;
        private const byte hPhysics     = 6;
        private const byte hPolishLang  = 7;
        private const byte hForeignLang = 8;

        public Main()
        {
           

            InitializeComponent();

            RefreshDiary();

            SetColumnHeader();

        }

        public void DisplayMessage1(string message)
        {
            MessageBox.Show($"Metoda 1 - {message}");
        }

        public void DisplayMessage2(string message)
        {
            MessageBox.Show($"Metoda 2 - {message}");
        }


        private void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;
        }

        private void SetColumnHeader()
        {
            dgvDiary.Columns[hId].HeaderText = "Numer";
            dgvDiary.Columns[hFirstName].HeaderText = "Imię";
            dgvDiary.Columns[hLastName].HeaderText = "Nazwisko";
            dgvDiary.Columns[hComents].HeaderText = "Uwagii";
            dgvDiary.Columns[hMath].HeaderText = "Matematyka";
            dgvDiary.Columns[hTechnology].HeaderText = "Technologia";
            dgvDiary.Columns[hPhysics].HeaderText = "Fizyka";
            dgvDiary.Columns[hPolishLang].HeaderText = "Język polski";
            dgvDiary.Columns[hForeignLang].HeaderText = "Język obcy";

            
        }



        public void SerializeToFileWithTryFinally(List<Student> students)
        {
            var serialize = new XmlSerializer(typeof(List<Student>));
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(Program.FilePath);
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

            using (var streamWriter = new StreamWriter(Program.FilePath))
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
                streamWriter = new StreamWriter(Program.FilePath);
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
            RefreshDiary();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę, zaznacz ucznia któego dane chcesz usunąć.");
                return;
            }

            var selectedStudent = dgvDiary.SelectedRows[0];
            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia " +
                $"{(selectedStudent.Cells[1].Value.ToString() + " " + selectedStudent.Cells[2].Value.ToString()).Trim()}",
                "Usuwanie Ucznisa",MessageBoxButtons.OKCancel);
            if(confirmDelete == DialogResult.OK)
            {

                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
                RefreshDiary();
            }
          
        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę, zaznacz ucznia którego dane chcesz edytować.");
                return;
            }

            var addEditStudent = new AddEditStudent(Convert.ToInt32( dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.ShowDialog();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.ShowDialog();

        }
    }
}
