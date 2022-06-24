using System;

namespace HomeWork_4_11
{
    class Program
    {

        static private void ShowEvenOrAddNumber_KS()
        {
            Console.WriteLine("Podaj liczbę, a ja odpowiem czy jest to liczba parzysta czy nie parzysta.");
            while (true)
            {
                int number = GetValue();
                if (number % 2 == 0)
                    Console.WriteLine("Podana liczba jest parzysta.");
                else
                    Console.WriteLine("Podana liczba jest nieparzysta.");

                Console.WriteLine("\nPodaj następną liczbę. Jeżeli chcesz wyjść z aplikacji wpisz 't'.");

            }
        }

        private static int GetValue()
        {
            while (true)
            {
                var val = Console.ReadLine();
                if (val.ToUpper() == "T")
                    Environment.Exit(0);
                if (! int.TryParse(val, out int number))
                {
                    Console.WriteLine("Podałaś nieprawidłowe dane. Spróbuj ponownie.");
                    continue;
                }
                return number;
            }
        }

        static private void ShowEvenOrAddNumber()
        {
            Console.WriteLine("Podaj liczbę do sprawdzenia : ");

            int liczba = GetInput();
            if (liczba % 2 == 0){
                Console.WriteLine("Liczba parzysta");
            }
            else
            {
                Console.WriteLine("Liczba nieparzysta"); 
            }

        }

        static private int GetInput()
        {
            if(! int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Nie wprowadzono prawidłowej wartości.");
            }
            return input;
        }

        static void Main(string[] args)
        {
            try
            {
                ShowEvenOrAddNumber_KS();
                //ShowEvenOrAddNumber();
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
