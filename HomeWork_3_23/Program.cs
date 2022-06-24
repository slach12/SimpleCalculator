using System;

namespace HomeWork_3_23
{
    class Program
    {
        
        private static int GetNumber()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Wprowadzony znak nie jest liczbą. Podaj prawidłową liczbę.");
                    continue;
                }
                return input;
            }

        }
        private static void Task()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(100);
            Console.WriteLine("Zgadnij wylosowaną liczbę : ");
            int trial = 1;
            while (true)
            {
                var guesNumber = GetNumber();
                if ( guesNumber == randomNumber)
                {
                    Console.WriteLine($"Brawo zgadłeś po {trial} próbach, wylosowana liczba to : {randomNumber}");                                                              

                    break;
                }
                else if 
                    (guesNumber < randomNumber)
                {
                    Console.WriteLine("Twoja liczba jest za mała. Spróbuj jeszcze raz !");
                }
                else
                {
                    Console.WriteLine("Twoja liczba jest za duża. Spróbuj jeszcze raz !");
                }
                trial++;        
            }
        }
        static void Main(string[] args)
        {            
            try
            {
                Task();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
            
        }
    }
}
