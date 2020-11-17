using System;
using System.Collections.Generic;
using HotelClassLibrary;

namespace ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
                    Console.WriteLine("\nStaff login");
                    TryLogin();
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







            //Funktioner

            void ChoiceForGuest(HotelManager hotelManager)
            {
                var choice = Console.ReadKey();
                int number;

                Console.WriteLine("[1] - Book room\n[2] - Log in");

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        //Book room
                        break;
                    case ConsoleKey.D2:
                        // LOG IN
                        System.Console.WriteLine("[ENTER] - LOG IN\n[N] - new account");
                        var logInChoice = Console.ReadKey();

                        switch (logInChoice.Key)
                        {
                            case ConsoleKey.Enter:
                            TryLogin();

                                break;
                            case ConsoleKey.N:
                                //userAuthentication.AddGuestUser();
                                break;

                            default:
                                break;
                        }

                        //HÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄR

                        break;

                    default:
                        break;
                }
                Console.Write("We have rooms for 1-6 persons. For how many persons in the room? : ");
                int numberOfPersons = Convert.ToInt16(Console.ReadLine());
                List<Room> availableRooms = hotelManager.CreateListOfAvailableRooms(numberOfPersons);

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
                            string password;
                            string userName;

                            Console.WriteLine("Add staff useraccount");
                            Console.Write("Firstname: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Lastname: ");
                            string lastName = Console.ReadLine();

                            do
                            {
                                Console.Write("Type in a username with 6 to 16 characters \nUsername: ");
                                userName = Console.ReadLine();
                                isUserExisting = userAuthentication.CheckIfUsernameExist(userName);
                                Console.Write("Type in a password with 6 to 16 characters \nPassword: ");
                                password = Console.ReadLine();

                                if (userName.Length < 6 || userName.Length > 16)
                                {
                                    isUserExisting = false;
                                    Console.WriteLine("Username can only contain 6 to 16 characters");
                                    Console.ReadKey();
                                }
                                else if (password.Length < 6 || password.Length > 16)
                                {
                                    isUserExisting = false;
                                    Console.WriteLine("Password can only contain 6 to 16 characters");
                                    Console.ReadKey();
                                    Console.Write("Type in a password with 6 to 16 characters \nPassword: ");
                                    password = Console.ReadLine();
                                }
                                else if (isUserExisting == false && userName.Length > 6 && password.Length < 16)
                                {
                                    isUserExisting = true;
                                    userAuthentication.AddStaffUser(userName, password, firstName, lastName);
                                    Console.WriteLine("User successfully added");
                                    Console.Write("Press any key to continue");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("Username already exists\n");
                                    Console.Write("Press any key to do another try");
                                    Console.ReadKey();
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

            void TryLogin()
            {
                string userName;
                string password;

                do
                {
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
            
            }

        }


    }
}