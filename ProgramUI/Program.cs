using System;
using System.Collections.Generic;
using HotelClassLibrary;

namespace ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string password;
            bool isUserValid;
            int loginTry = 1;

            HotelManager hotelManager = new HotelManager();
            hotelManager.AddRoom();
            UserAuthentication userAuthentication = new UserAuthentication();
            userAuthentication.AddStaffUser("user", "pass", "firstname", "lastname");
            Console.WriteLine("Welcome to hotel Push n Pull");
            Console.WriteLine("Make a choice");
            Console.WriteLine("Press 1: Staff");
            Console.WriteLine("Press 2: Guest");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1: //Staff Login
                    do
                    {
                        Console.WriteLine("Staff login");
                        Console.Write("Username: ");
                        userName = Console.ReadLine();

                        userAuthentication.CheckIfUsernameExist(userName);

                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        userAuthentication.TryValidateStaffUser(userName, password);
                        isUserValid = userAuthentication.TryValidateStaffUser(userName, password);
                        if (isUserValid == true)
                        {
                            Console.WriteLine("Login succeded");
                            ChoiceForStaff();
                        }
                        else
                        {
                            Console.WriteLine($"Wrong user name or password. Do another try.\n Try {loginTry++} of 3");
                        }
                    } while (loginTry <= 3);
                    break;

                case ConsoleKey.D2: //Guest login
                    ChoiceForGuest(hotelManager);

                    /*Console.WriteLine ("Guest login");
                    Console.Write ("Username: ");
                    userName = Console.ReadLine ();
                    Console.Write ("Password: ");
                    password = Console.ReadLine ();

                    userAuthentication.TryValidateGuestUser (userName, password);*/

                    break;

                default:
                    break;



                    static void ChoiceForGuest(HotelManager hotelManager)
                    {
                        int input;
                        int number;


                        Console.WriteLine("---------Book room---------");
                        System.Console.Write("We have rooms for 1-6 persons. For how many persons in the room? : ");
                        input = Convert.ToInt16(Console.ReadKey());
                        hotelManager.CreateListOfAvailableRooms(input);


                        Console.WriteLine("Wich room do you want to book?");
                        Console.Write("Choose the number of the room you want to book : ");
                        number = Convert.ToInt16(Console.ReadLine());



                        /*                                  TA BORT?????????????????????????????!!!
                                    switch (input.Key) {
                                        case ConsoleKey.D1:
                                            //se lediga rum

                                            //string roomDescriptions = "";

                                            // foreach (Room room in availableRooms) {
                                            //     roomDescriptions += "Number of beds: " + room.NumberOfBeds + ".\n" +
                                            //         "Price per night: " + room.PricePerNight + " SEK.\n" +
                                            //         "Square meters: " + room.SquareMeters + ".";
                                            // }

                                            break;

                                        case ConsoleKey.D2:
                                            // se bokat rum

                                            break;

                                        default:
                                            break;*/
                    }


                    static void ChoiceForStaff()
                    {                         /// BYGG OM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        Console.WriteLine("STAFF LOGIN");
                        Console.WriteLine("Make a choice below");
                        Console.WriteLine("STAFF LOGIN");
                        var input = Console.ReadKey();

                        switch (input.Key)
                        {
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
    }
}
