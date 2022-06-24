using System;

namespace HomeWork_3_20
{
    class Program
    {
        private static int GetYear()
        {
            while (true) {
                var year = GetInput();
                if (year < 1922) {
                    Console.WriteLine($"Podałeś rok urodzenia: {year}. Jest to nie prawidłowy rok albo masz ponad 100 lat. ");
                } else if (year > DateTime.Now.Year) {
                    Console.WriteLine($"Podałeś rok urodzenia: {year}. Jest to nie prawidłowy rok.");
                }
                else {
                    return year;
                }                                                      
            }
        }


        private static int GetMonth()
        {
            while (true)
            {
                var month = GetInput();
                if (month>0 && month<12)
                {
                  return month;
                }
                else {                    
                  Console.WriteLine($"Podałeś miesiąc urodzenia: {month}. Jest to nieprawidłowy miesiąc.");
                }
            }
        }


        private static int GetDay(int yearOfBirth, int monthOfBirth)
        {
            while (true)
            {
                var day = GetInput();
                if (day > 0 && day <= DateTime.DaysInMonth(yearOfBirth,monthOfBirth))
                {
                    return day;
                }
                else if (day>DateTime.DaysInMonth(yearOfBirth, monthOfBirth)){
                    Console.WriteLine($"Podałeś dzień urodzenia: {day}. Jest to nieprawidłowy dzień. {monthOfBirth} miesiąc w {yearOfBirth} roku miał {DateTime.DaysInMonth(yearOfBirth,monthOfBirth)} dni.");
                } 
                else
                {
                    Console.WriteLine($"Podałeś dzień urodzenia: {day}. Jest to nieprawidłowy dzień.");
                }
            }
        }

        private static int GetInput()
        {
            if (! int.TryParse(Console.ReadLine() ,out int input)){

                throw new Exception("Nie wprowadzona prawidłowej liczby.");
            }
            return input;
        }
        static void Task()
        {
            Console.WriteLine("Praca domowa!");
            string name;
            string bornPlace;
            int bornYear, bornMonth, bornDay, bornAge;
            Console.WriteLine("Podaj sowje imię: ");
            name = Console.ReadLine();

            Console.WriteLine("Podaj rok sowjego urodzenia: ");
            bornYear = GetYear();
            
          
            Console.WriteLine("Podaj miesiąc (w postaci liczby) sowjego urodzenia: ");
            bornMonth = GetMonth();
         
            Console.WriteLine("Podaj dzień miesiąca sowjego urodzenia: ");
            bornDay = GetDay(bornYear,bornMonth);
            
            Console.WriteLine("Podaj miejsce swojego urodzenia: ");
            bornPlace = Console.ReadLine();

            DateTime BornDate = new DateTime(bornYear, bornMonth, bornDay);
            DateTime NowDate = DateTime.Now;
            bornAge = NowDate.Year - BornDate.Year;
            if (NowDate.DayOfYear < BornDate.DayOfYear)
                bornAge -= 1;

            Console.WriteLine($"Cześć {name}. Urodziłęś sie w {bornPlace} i masz {bornAge} lat.");
        }

        static void Main(string[] args)
        {
            try
            {
                Task();
            }
            catch(Exception Exc)
            {
                Console.WriteLine(Exc.Message);
            } 
            finally
            {
                Console.ReadLine();
            }    
        }
    }
}
