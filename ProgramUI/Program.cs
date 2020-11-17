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
            Console.WriteLine("Press 3: Exit");
            Console.Write("Choice: ");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1: //Staff Login
                    do
                    {
                        Console.WriteLine("\nStaff login");
                        Console.Write("Username: ");
                        userName = Console.ReadLine();

                        //userAuthentication.CheckIfUsernameExist(userName); kolla username finns, när skapa användare

                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        userAuthentication.TryValidateStaffUser(userName, password);
                        isUserValid = userAuthentication.TryValidateStaffUser(userName, password);

                        if (isUserValid == true)
                        {
                            Console.WriteLine("Login succeded");

                            ChoiceForStaff(hotelManager, userAuthentication);

                        }
                        else
                        {
                            Console.WriteLine($"Wrong user name or password. Do another try.\nTry {loginTry++} of 3");
                        }
                    }
                    while (loginTry <= 3);
                    Console.WriteLine("Number of tries overriden.");
                    ExitProgram();
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

                case ConsoleKey.D3:
                    ExitProgram();
                    break;

                default:
                    Console.WriteLine("Wrong input. You can only press 1 or 2");
                    Console.ReadKey();
                    break;
            }

            static void ExitProgram()
            {
                Console.WriteLine("\nProgram exits");
                Environment.Exit(0);
            }

            static void ChoiceForGuest(HotelManager hotelManager)
            {
                int input;
                int number;


                Console.WriteLine("-------Book room---------");
                Console.Write("We have rooms for 1-6 persons. For how many persons in the room? : ");
                input = Convert.ToInt16(Console.ReadKey());
                List<Room> availableRooms = hotelManager.CreateListOfAvailableRooms(input);

                Console.WriteLine(PrintAvailableRooms(availableRooms));

                Console.WriteLine("Wich room do you want to book?");
                Console.Write("Choose the number of the room you want to book : ");
                number = Convert.ToInt16(Console.ReadLine());
            }

            static string PrintAvailableRooms(List<Room> availableRooms)
            {
                string roomDescriptions = "";

                int index = 1;

                for (int i = 1; i < availableRooms.Count + 1; i++)
                {
                    roomDescriptions += "Number of beds: " + availableRooms[i].NumberOfBeds + "\n" +
                    "Square meters: " + availableRooms[i].SquareMeters + "\n" +
                    "Price per night: " + availableRooms[i].PricePerNight + "\n";

                    index++;
                }
                return roomDescriptions;
            }




            static void ChoiceForStaff(HotelManager hotelManager, UserAuthentication userAuthentication)
            {
                do
                {
                    Console.WriteLine("STAFF");
                    Console.WriteLine("Make a choice below");
                    Console.WriteLine($"[1] - Check out guest\n[2] - Book room\n[3] - View all rooms \n[4] - View all Avalible rooms\n[5] - Add new staff useraccount\n[6] - Add new room \n[7] - Exit program");
                    Console.Write("Choice: ");
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {

                        case ConsoleKey.D1:
                        //check out
                        int roomNumber;

                            System.Console.Write("Check out room number :");
                            roomNumber = Convert.ToInt16(Console.ReadLine());
                            hotelManager.CheckIfRoomIsPaid(roomNumber);


                            // checkOutGuest
                            //payRoom?
                            // MakeRoomAvalible
                            break;

                        case ConsoleKey.D2:
                            // Book room
                            break;

                        case ConsoleKey.D3:
                            // View all rooms
                            Console.WriteLine(hotelManager.ViewAllRooms());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D4:
                        //View all Avalible rooms
                        break;
                        
                        case ConsoleKey.D5:
                            //Add staff
                            bool isUserExisting;
                            do
                            {
                                Console.WriteLine("Add staff useraccount");
                                Console.Write("Type in a username: ");
                                string userName = Console.ReadLine();
                                isUserExisting = userAuthentication.CheckIfUsernameExist(userName);
                                if (isUserExisting == true)
                                {
                                    Console.Write("Type in a good password");
                                    string password = Console.ReadLine();
                                    Console.Write("Firstname: ");
                                    string firstName = Console.ReadLine();
                                    Console.Write("Lastname: ");
                                    string lastName = Console.ReadLine();
                                    userAuthentication.AddStaffUser(userName, password, firstName, lastName);
                                    Console.WriteLine("User successfully added");
                                }
                                else
                                {
                                    Console.WriteLine("Username already exists");
                                }
                            } while (isUserExisting == false);

                            break;

                        case ConsoleKey.D6:
                        //add new room

                            System.Console.WriteLine("Add a new room to the hotel\n");

                            
                            int squareMeters;
                            int numberOfBeds;
                            int pricePerNight;

                            System.Console.WriteLine("Room number :");
                            roomNumber = Convert.ToInt16(Console.ReadLine());
                            System.Console.WriteLine("Square meters :");
                            squareMeters = Convert.ToInt16(Console.ReadLine());
                            System.Console.WriteLine("Number of beds :");
                            numberOfBeds = Convert.ToInt16(Console.ReadLine());
                            System.Console.WriteLine("Price per night :");
                            pricePerNight = Convert.ToInt16(Console.ReadLine());

                            hotelManager.AddNewRoom(roomNumber, squareMeters, numberOfBeds, pricePerNight);
                            break;

                        case ConsoleKey.D7:
                            //Exit
                            ExitProgram();
                            break;

                        default:
                            Console.WriteLine("Wrong input. You can only make a choice between 1-7");
                            Console.ReadKey();
                            break;

                    }
                } while (true);
            }

        }
    }
}

