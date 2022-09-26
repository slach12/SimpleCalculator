using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
            
    }

    internal class Student2 : Student
    {

    }
    public  class Student :Person
    {
        public Student()
        {
            Address = new Address();
        }
 
        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string PolishLang { get; set; }
        public string ForeignLang { get; set; }

        public Address Address { get; set; }

        public string GetStudentInfo()
        {
            return $"{FirstName} {LastName} - Oceny z matematyki : {Math} ";
        }

        

        public override string GetInfo()
        {
            return $"{FirstName} {LastName} - Oceny z matematyki : {Math} ";
        }
        //public void add(int id)
        //{

        //}
        //public void add(string coment)
        //{

        //}
        //public void add(int id, string firstname)
        //{

        //}
        //public void add(int id, string firstname, string lastname)
        //{

        //}


    }

    public class Teacher : Person
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Coments { get; set; } 
        public string Position { get; set; }

        public string GetTeacherInfo()
        {
            return $"{FirstName} {LastName} - Nauczyciel.";
        }
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} - Nauczyciel.";
        }
    }

    public interface IPerson
    {
        string GetInfo();
    }
    public abstract class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Coments { get; set; }

        public abstract string GetInfo();
    }
}
