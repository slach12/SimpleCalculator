using System;
/*
Gra FizzBuzz
-Jeżeli liczba użytkownika będzie podzielna przez 3 bez reszty,
    to powinien zostać zwrócony wynik „Fizz”.
-Jeżeli liczba użytkownika będzie podzielna przez 5 bez reszty, 
    to powinien zostać zwrócony wynik „Buzz”.
-Jeżeli liczba użytkownika będzie podzielna przez 3 i przez 5 jednocześnie bez reszty, 
    to powinien zostać zwrócony wynik „FizzBuzz”.
-Jeżeli liczba użytkownika nie będzie podzielna przez 3 ani przez 5 bez reszty, 
    to wtedy zwracasz podaną liczbę.
*/

namespace HomeWork_4_13
{
    class Program
    {

        static private int GetIput()
        {
            if(! int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Podałeś nie poprawną liczbę.");
            }
            return input;
        }

        static private void PlayFizzBuzz()
        {
            Console.WriteLine("Podaj liczbę do sprawdzenia: ");
            var fizzBuzz = new FizzBuzz();
            fizzBuzz.Number = GetIput();
            Console.WriteLine(fizzBuzz.Game());

        }

        static private void PlayFizzBuzz_KS()
        {
            Console.WriteLine("Witaj w grze FizzBuzz.");
            var fizzBuzz = new FizzBuzz();
            while (true)
            {
                Console.WriteLine("Podaj proszę liczbę :");
                var number = GetNumber();
                Console.WriteLine(fizzBuzz.GetOutput(number));
            }
        }

        private static int GetNumber()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(),out int number))
                {
                    Console.WriteLine("Podałeś nie prawidłowe dane. Spróbuj ponownie.");
                    continue;
                }
                return number;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //PlayFizzBuzz();
                PlayFizzBuzz_KS();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
