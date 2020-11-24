using System;
using System.Collections.Generic;
using HotelClassLibrary;

namespace ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGuestUserValid = false;
            bool isStaffUserValid = false;
            int loginTry = 1;
            string firstName = "";
            string lastName = "";
            int guestId = 0;

            ConsoleKeyInfo guestOrStaff;
            HotelManager hotelManager = new HotelManager();         
            UserAuthentication userAuthentication = new UserAuthentication();

            AddRoom();
            userAuthentication.AddStaffUser("username", "password", "firstname", "lastname");
            userAuthentication.AddGuestUser("Kalle", "Johansson", "guestuser", "password", "Kalle@gmail.com", 0703556585, "Göstasväg 2", 50762, "Borås", 5960660045456500);
            hotelManager.BookRoom(2, 1);
            
            while (true)
            {
                Console.WriteLine("\nWelcome to hotel Push n Pull");
                Console.WriteLine("Make a choice");
                Console.WriteLine("Press [1]: Guest");
                Console.WriteLine("Press [2]: Staff");
                Console.WriteLine("Press [Esc]: Exit program");
                Console.Write("Choice: ");

                guestOrStaff = Console.ReadKey();

                switch (guestOrStaff.Key)
                {
                    case ConsoleKey.D1: //Guest login
                        Console.Clear();
                        ChoiceForGuest(hotelManager);
                        break;

                    case ConsoleKey.D2: //Staff Login hehe
                        Console.Clear();
                        Console.WriteLine("\nStaff login");
                        TryLogin();
                        ChoiceForStaff(hotelManager, userAuthentication);
                        break;

                    case ConsoleKey.Escape:
                        ExitProgram();
                        break;

                    default:
                        Console.WriteLine("Wrong input. You can only press [1], [2] or [Esc]");
                        Console.ReadKey();
                        break;
                }
            }







            //Här kommer alla metoder till main


            //CHOISE FOR GUEST
            void ChoiceForGuest(HotelManager hotelManager)
            {
                ConsoleKeyInfo bookingMenuChoice;
                            Console.Clear();
                    Console.WriteLine("Welcome guest");
                do
                {

                            //Book room
                            Console.Write("We have rooms for 1-6 persons. \nHow many persons? : ");
                            int numberOfBeds = Convert.ToInt16(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Rooms that are avalible for you\n");

                            string rooms = PrintAvailableRooms(numberOfBeds);
                            Console.WriteLine(rooms);

                            Console.WriteLine("[1] - Book a room\n[2] - Change number of beds\n[Esc] - Return to main menu");
                            Console.Write("Choice: ");
                            bookingMenuChoice = Console.ReadKey();

                            switch (bookingMenuChoice.Key)
                            {
                                case ConsoleKey.D1:
                                    System.Console.WriteLine("\n- Book room -\n");
                                    Console.Write("Wich room do you want to book : ");
                                    int numberOfRoom = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("\nLogin or create a new account to continue\n");

                                    Console.WriteLine("[1] - Login \n[2] - Create new account");
                                    Console.Write("Choice: ");
                                    bookingMenuChoice = Console.ReadKey();

                                    if (bookingMenuChoice.Key == ConsoleKey.D1)
                                    {
                                        TryLogin();
                                    }
                                    else if (bookingMenuChoice.Key == ConsoleKey.D2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nNew user\n");
                                        Console.WriteLine("Please, fill in the fields below\n");
                                        GetNames(firstName, lastName);
                                        CreateAccount(firstName, lastName, guestOrStaff);
                                    }

                                    //felhantering här
                                    hotelManager.BookRoom(numberOfRoom, guestId); 
                                    Console.WriteLine("\nYour booking is confirmed!\n");
                                    Console.Write("Press any key to exit");
                                    Console.ReadKey();
                                    ExitProgram();
                                    break;

                                case ConsoleKey.D2:
                                //Breakar loop och återgår till välja antalet bäddar                               
                                    break;

                                default:
                                    Console.WriteLine("\nWrong input. You can only press [1], [2] or [Esc]\n");
                                    break;
                            }                            

                        //case ConsoleKey.D2:
                            // Console.Clear();
                            // Console.WriteLine("[1] - Login \n[2] - Create new account");
                            // Console.Write("Choice: ");

                            // var logInChoice = Console.ReadKey();

                            // switch (logInChoice.Key)
                            // {
                            //     case ConsoleKey.D1:
                            //         Console.Clear();
                            //         Console.WriteLine("Type in your login details");
                            //         TryLogin();
                            //         Console.WriteLine("\nYour booking is confirmed!\n");
                            //         ExitProgram();
                            //         break;

                            //     case ConsoleKey.D2: //Create new user account
                            //         Console.Clear();
                            //         Console.WriteLine("ADD NEW GUEST USERACCOUNT");
                            //         Console.Write("\nFirstname: ");
                            //         string firstName = Console.ReadLine();
                            //         Console.Write("Lastname: ");
                            //         string lastName = Console.ReadLine();
                            //         CreateAccount(firstName, lastName, guestOrStaff);
                            //         break;

                            //     default:
                            //         Console.WriteLine("Wrong input. You can only press 1 or 2");
                            //         break;
                            // }
                            //break;

                } while (bookingMenuChoice.Key != ConsoleKey.Escape);
            }

            // FOR STAFF

            void ChoiceForStaff(HotelManager hotelManager, UserAuthentication userAuthentication)
            {
                ConsoleKeyInfo input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("STAFF\n");
                    Console.WriteLine("Make a choice below");
                    Console.WriteLine("[1] - Check out guest\n[2] - View all rooms\n[3] - View all Avalible rooms\n[4] - Add new staff useraccount\n[5] - Add new room \n[6] - Exit program");
                    Console.Write("Choice: ");
                    input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            //checkout
                            int roomNumber;
                                Console.Clear();

                            do
                            {

                                System.Console.Write("Check out room number :");
                                roomNumber = Convert.ToInt32(Console.ReadLine());
                                bool isBooked = hotelManager.IsBooked(roomNumber);
                                
                                if (isBooked == true)
                                {
                                    PaymentNotice paymentNotice = hotelManager.CheckoutGuest(roomNumber);
                                    Console.WriteLine("\nDo not forget to charge the creditcard.\n");
                                    hotelManager.PayRoom(roomNumber);
                                    System.Console.WriteLine($"Room {roomNumber} is now avalible!");
                                    Console.Write("Press any key to continue the check out.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The room number you entered isn't booked!");
                                }
                            } while (true);
                            
                            break;

                        case ConsoleKey.D2:
                            // View all rooms
                            Console.Clear();
                            Console.WriteLine(hotelManager.ViewAllRooms());
                            Console.Write("Press any key to return");
                            Console.ReadKey();
                            break;
                            
                        case ConsoleKey.D3:
                            //View all Avalible rooms
                            Console.Clear();
                            string output = PrintAllAvailableRooms();
                            Console.WriteLine(output);
                            Console.Write("Press any key to return");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D4:
                            //Add staff
                            Console.Clear();
                            Console.WriteLine("ADD NEW STAFF USERACCOUNT\n");
                            Console.Write("Firstname: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Lastname: ");
                            string lastName = Console.ReadLine();
                            CreateAccount(firstName, lastName, guestOrStaff);
                            break;

                        case ConsoleKey.D5:
                            //add new room
                             Console.Clear();
                            int squareMeters;
                            int numberOfBeds;
                            int pricePerNight;

                            Console.WriteLine("Add a new room to the hotel\n");
                            //FELHANTERING

                            Console.WriteLine("Room number :");
                            roomNumber = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                            Console.WriteLine("Square meters :");
                            squareMeters = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                            Console.WriteLine("Number of beds :");
                            numberOfBeds = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                            Console.WriteLine("Price per night :");
                            pricePerNight = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                            hotelManager.AddNewRoom(roomNumber, squareMeters, numberOfBeds, pricePerNight);
                            Console.WriteLine("Room added successfully\nPress any key to continue");
                            Console.ReadKey();
                            break;
                            
                        case ConsoleKey.D6:
                            //Exit
                            ExitProgram();
                            break;
                            
                        case ConsoleKey.Escape: // Återgå till main menu
                            break;
                            
                        default:
                            Console.WriteLine("Wrong input. You can only make a choice between 1-6");
                            Console.ReadKey();
                            break;
                    }
                } while (input.Key != ConsoleKey.Escape);
            }

            // LOG IN

            void TryLogin()
            {
                string userName;
                string password;

                do
                {
                    Console.Write("Username: ");
                    userName = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    switch (guestOrStaff.Key)
                    {
                        case ConsoleKey.D2:
                            isStaffUserValid = userAuthentication.TryValidateStaffUser(userName, password);
                            break;
                        case ConsoleKey.D1:
                            isGuestUserValid = userAuthentication.TryValidateGuestUser(userName, password);
                            break;
                    }

                    if (isGuestUserValid == true || isStaffUserValid == true)
                    {
                        Console.WriteLine("Login succeded");
                        loginTry = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Wrong username or password. Do another try.\nTry {loginTry++} of 3");
                        if (loginTry == 4)
                        {
                            Console.WriteLine("Number of tries overriden");
                            Console.ReadKey();
                            ExitProgram();
                        }
                    }
                }
                while (true);                
            }

            // CREATE NEW ACCOUNT

            void CreateAccount(string firstName, string lastName, ConsoleKeyInfo guestOrStaff)
            {
                bool isUserExisting = false;
                do
                {
                    string password;
                    string userName;
                    do
                    {
                        Console.Write("Type in a username with 6 to 16 characters \nUsername: ");
                        userName = Console.ReadLine();
                        isUserExisting = userAuthentication.CheckIfUsernameExist(userName);

                        if (userName.Length < 6 || userName.Length > 16)
                        {
                            Console.WriteLine("Username must contain 6 to 16 characters");
                            Console.Write("Press any key to do another try");
                            Console.ReadKey();
                        }
                        else if (isUserExisting == true)
                        {
                            Console.WriteLine("Username already exists");
                            Console.Write("Press any key to do another try");
                            Console.ReadKey();
                        }
                        
                    } while (userName.Length < 6 || userName.Length > 16 || isUserExisting == true);

                    do
                    {
                        Console.Write("Type in a password with 6 to 16 characters \nPassword: ");
                        password = Console.ReadLine();

                        if (password.Length < 6 || password.Length > 16)
                        {
                            Console.WriteLine("Password must contain 6 to 16 characters");
                            Console.ReadKey();
                        }
                        
                    } while (password.Length < 6 || password.Length > 16);

                    if (guestOrStaff.Key == ConsoleKey.D2)
                    {
                        userAuthentication.AddStaffUser(userName, password, firstName, lastName);
                        Console.WriteLine("STAFF ADDED");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        GetGuestDetails(firstName, lastName, userName, password);                        
                    }

                    break;
                    
                } while (isUserExisting == true);
            }

            void GetGuestDetails(string firstName, string lastName, string userName, string password)
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Phone number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                Console.Write("Street address: ");
                string streetAddress = Console.ReadLine();
                Console.Write("Postal code: ");
                int postalCode = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("Creditcard number: ");
                long creditCardNumber = Convert.ToInt64(Console.ReadLine()); //TRY CATCH

                var output = userAuthentication.AddGuestUser(firstName, lastName, userName, password, email, phoneNumber, streetAddress, postalCode, city, creditCardNumber);
                Console.Clear();
                Console.WriteLine("New account created!\n");
                Console.WriteLine($"Your guest id is: {output.GuestId}. \nPlease save your guest id for further use in the booking system.");
                guestId = output.GuestId;
            }

            // PRINT AVALIBLE ROOMS

            string PrintAvailableRooms(int numberOfBeds)
            {
                string printSpecificAvailableRooms = "";
                int index = 1;
                List<Room> availableRooms = hotelManager.AddToListOfAvailableRooms(numberOfBeds);

                for (int i = 0; i < availableRooms.Count; i++)
                {
                    printSpecificAvailableRooms += "[" + index + "] Number of beds: " + availableRooms[i].NumberOfBeds + "\n" +
                        "Square meters: " + availableRooms[i].SquareMeters + "\n" +
                        "Price per night: " + availableRooms[i].PricePerNight + "\n\n";
                    index++;
                }
                
                return printSpecificAvailableRooms;
            }

            string PrintAllAvailableRooms()
            {
                string printAvailableRooms = "";
                List<Room> availableRooms = hotelManager.AddToListOfAvailableRooms();

                foreach (Room room in availableRooms)
                {
                    printAvailableRooms += room.RoomNumber + "\n" +
                        "Number of beds: " + room.NumberOfBeds + "\n" +
                        "Square meters: " + room.SquareMeters + "\n" +
                        "Price per night: " + room.PricePerNight + "\n\n";
                }

                return printAvailableRooms;
            }

            void AddRoom()
            {
                hotelManager.AddNewRoom(101, 65, 4, 2233);
                hotelManager.AddNewRoom(102, 63, 3, 1933);
                hotelManager.AddNewRoom(103, 62, 4, 2133);
                hotelManager.AddNewRoom(201, 45, 3, 3233);
                hotelManager.AddNewRoom(202, 67, 2, 2233);
                hotelManager.AddNewRoom(203, 17, 2, 3233);
                hotelManager.AddNewRoom(401, 14, 1, 2233);
                hotelManager.AddNewRoom(402, 21, 2, 4333);
                hotelManager.AddNewRoom(501, 20, 2, 2333);
                hotelManager.AddNewRoom(502, 20, 1, 2133);
            }

            void CheckUserInput(string input)
            {
                if (input.Length < 1)
                {
                    Console.WriteLine("You must fill in something");
                    Console.WriteLine("Press any key to do another try");
                    Console.ReadKey();
                }
            }

            void GetNames(string firstName, string lastName)
            {
                do
                {
                    Console.Write("Firstname: ");
                    firstName = Console.ReadLine();
                    CheckUserInput(firstName);

                } while (firstName.Length < 1);

                // if kan inte vara noll
                do
                {
                    Console.Write("Lastname: ");
                    lastName = Console.ReadLine();
                    CheckUserInput(lastName);

                } while (lastName.Length < 1);
            }

            void ExitProgram()
            {
                Console.WriteLine("\nProgram exits");
                Environment.Exit(0);
            }
        }
    }
}