using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class Calculate
    {
        static Calculate()
        {
            Console.WriteLine("Konstrukotr statyczny");
        }
         public static int sum (int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
