using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{


    public  class Student 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Coments { get; set; }

        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string PolishLang { get; set; }
        public string ForeignLang { get; set; }

        public string GetStudentInfo()
        {
            return $"{FirstName} {LastName} - Oceny z matematyki : {Math} ";
        }

        public string GetInfo()
        {
            return $"{FirstName} {LastName} - Oceny z matematyki : {Math} ";
        }
    }

 
}
