using System;
using HotelClassLibrary;

namespace ProgramUI {
    class Program {
        static void Main (string[] args) {
            string userName;
            string password;            

            UserAuthentication userAuthentication = new UserAuthentication ();
           // userAuthentication.AddUser("name", "password");

            System.Console.WriteLine ("1- staff / 2- guest");

            var input = Console.ReadKey ();

            switch (input.Key) {
                case ConsoleKey.D1:
                    ChoiceForStaff (input);

                    break;

                case ConsoleKey.D2:
                    Console.WriteLine ("Staff login");
                    Console.Write ("Username: ");
                    userName = Console.ReadLine ();
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    userAuthentication.TryValidateUser(userName, password);

                    ChoiceForGuest (input);

                    break;

                default:
                    break;
            }

        }
        static void ChoiceForGuest (ConsoleKeyInfo consoleKey) {
            System.Console.WriteLine ("gör något av följande val....");
            var input = Console.ReadKey ();

            switch (input.Key) {
                case ConsoleKey.D1:
                    //se lediga rum

                    break;

                case ConsoleKey.D2:
                    // se bokat rum

                    break;

                default:
                    break;
            }
        }

        static void ChoiceForStaff (ConsoleKeyInfo consoleKey) {
            System.Console.WriteLine ("gör något av följande val....");
            var input = Console.ReadKey ();

            switch (input.Key) {
                case ConsoleKey.D1:
                    // checkInGuest
                    // MakeRoomUnavalible
                    break;

                case ConsoleKey.D2:
                    // checkOutGuest
                    //payRoom
                    // MakeRoomAvalible
                    break;

                case ConsoleKey.D3:
                    // BookRoom
                    break;

                case ConsoleKey.D4:
                    // Add Room
                    break;

                default:
                    break;
            }
        }

    }
}