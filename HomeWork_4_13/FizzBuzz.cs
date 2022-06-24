using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_13
{
    public class FizzBuzz
    {
        public string GetOutput(int number)
        {
            if (number % 15 == 0 )
                return "FizzBuzz";
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
        }


        public int Number;
        private bool IsDivdedThree()
        {
            return Number % 3 == 0;
        }

        private bool IsDivdedFive()
        {
            return Number % 5 == 0;
        }

        private bool IsDivdedThreeAndFive()
        {
            return IsDivdedThree() && IsDivdedFive();
        }


        public string Game()
        {
            if (IsDivdedThreeAndFive())
                return "FizzBuzz";
            if (IsDivdedThree())
                return "Fizz";
            if (IsDivdedFive())
                return "Buzz";
            
            return Number.ToString();

        }
    }
}
