using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Robot
    {


        public string Name;
        private string _serialNumber;

        public Robot(string serialNumber)
        {
            _serialNumber = serialNumber;
            Console.WriteLine("Konstruktor.");
        }

        public void SayHello()
        {
            Console.WriteLine("Cześć, jestem robot. Mój numer seryjny to: "+_serialNumber);
        }
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public static void SayHelloStatic()
        {
            Console.WriteLine("Jestem robot. Wywołałeś metodę statycznyą.");
        }
    }
}
