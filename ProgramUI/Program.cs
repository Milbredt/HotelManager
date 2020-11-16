using System;

namespace ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("1- staff / 2- guest");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                ChoiceForStaff(input);

                break;

                case ConsoleKey.D2:
                 ChoiceForGuest(input);
                
                break;

                default:
                break;
            }







        }
        static void ChoiceForGuest(ConsoleKeyInfo consoleKey)
        {
            System.Console.WriteLine("gör något av följande val....");
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                
                 break;

                case ConsoleKey.D2:
                 break;

                case ConsoleKey.D3:
                 break;

                default:
                    break;
            }
        }


         static void ChoiceForStaff(ConsoleKeyInfo consoleKey)
         {

          var input = Console.ReadKey();

         switch (input.Key)
         {
             case ConsoleKey.D1:
             break;

             case ConsoleKey.D2:
             break;

             case ConsoleKey.D3:
             break;

             default:
             break;
         }
         }

    }
}
