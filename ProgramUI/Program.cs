using System;
using System.Collections.Generic;
using HotelClassLibrary;

namespace ProgramUI {
    class Program {
        static void Main (string[] args) {
            string userName;
            string password;

            HotelManager hotelManager = new HotelManager ();
            hotelManager.AddRoom ();
            UserAuthentication userAuthentication = new UserAuthentication ();
            userAuthentication.AddStaffUser ("user", "pass", "firstname", "lastname");

            System.Console.WriteLine ("1- staff / 2- guest");

            var input = Console.ReadKey ();

            switch (input.Key) {
                case ConsoleKey.D1: //Staff Login
                    Console.WriteLine ("Staff login");
                    Console.Write ("Username: ");
                    userName = Console.ReadLine ();

                    userAuthentication.CheckisUsernameExist(userName);

                    Console.Write ("Password: ");
                    password = Console.ReadLine ();
                    userAuthentication.TryValidateStaffUser (userName, password);
                    Console.WriteLine (userAuthentication.TryValidateStaffUser (userName, password));
                    ChoiceForStaff ();

                    break;

                case ConsoleKey.D2: //Guest login
                    ChoiceForGuest (hotelManager);
                    
                    /*Console.WriteLine ("Guest login");
                    Console.Write ("Username: ");
                    userName = Console.ReadLine ();
                    Console.Write ("Password: ");
                    password = Console.ReadLine ();

                    userAuthentication.TryValidateGuestUser (userName, password);*/


                    break;

                default:
                    break;
            }

        }
        static void ChoiceForGuest (HotelManager hotelManager) {
            System.Console.WriteLine ("gör något av följande val....");
            var input = Console.ReadKey ();

            switch (input.Key) {
                case ConsoleKey.D1:
                    //se lediga rum
                    List<Room> availableRooms = hotelManager.ViewAvailableRooms ();

                    string roomDescriptions = "";

                    foreach (Room room in availableRooms) {
                        roomDescriptions += "Number of beds: " + room.NumberOfBeds + ".\n" +
                            "Price per night: " + room.PricePerNight + " SEK.\n" +
                            "Square meters: " + room.SquareMeters + ".";
                    }

                    break;

                case ConsoleKey.D2:
                    // se bokat rum

                    break;

                default:
                    break;
            }
        }

        static void ChoiceForStaff () {
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