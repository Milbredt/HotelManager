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
            ConsoleKeyInfo guestOrStaff;


            HotelManager hotelManager = new HotelManager();
           // UIHandler uiHandler = new UIHandler();
            AddRoom();
            UserAuthentication userAuthentication = new UserAuthentication();
            userAuthentication.AddStaffUser("username", "password", "firstname", "lastname");
            userAuthentication.AddGuestUser("Kalle", "Johansson", "guestuser", "password", "Kalle@gmail.com", 0703556585, "Göstasväg 2", 50762, "Borås", 5960660045456500);

            while (true)
            {
                Console.WriteLine("Welcome to hotel Push n Pull");
                Console.WriteLine("Make a choice");
                Console.WriteLine("Press [1]: Guest");
                Console.WriteLine("Press [2]: Staff");
                Console.WriteLine("Press [Esc]: Exit");
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
                        Console.WriteLine("Wrong input. You can only press [1], [2] or [ESCAPE]");
                        Console.ReadKey();
                        break;
                }
            }

            //Här kommer alla metoder till main

            void ExitProgram()
            {
                Console.WriteLine("\nProgram exits");
                Environment.Exit(0);
            }

            //CHOISE FOR GUEST

            void ChoiceForGuest(HotelManager hotelManager)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome guest");
                    Console.WriteLine("Make a choice below");
                    Console.WriteLine("[1] - See our rooms and make a reservation");
                    Console.WriteLine("[2] - Log in or create an new account");
                    Console.Write("Choice: ");

                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            //Book room
                            Console.Clear();
                            Console.Write("We have rooms for 1-6 persons. \nHow many persons? : ");
                            int numberOfBeds = Convert.ToInt16(Console.ReadLine());

                            string rooms = PrintAvailableRooms(numberOfBeds);
                            Console.WriteLine(rooms);

                            System.Console.WriteLine("[1] - Book a room\n[2] - Change number of beds\n[3] - Return to main menu");
                            Console.Write("Choice: ");
                            var bookingMenuChoice = Console.ReadKey();

                            switch (bookingMenuChoice.Key)
                            {
                                case ConsoleKey.D1:

                                    System.Console.WriteLine("\n- Book room -");
                                    break;

                                case ConsoleKey.D2:
                                    System.Console.WriteLine("Change number of beds");
                                    int newInputOfNumberOfBeds = Convert.ToInt16(Console.ReadLine());
                                    numberOfBeds = newInputOfNumberOfBeds;
                                    break;

                                case ConsoleKey.D3:
                                    System.Console.WriteLine("Returning to the main menu...");
                                    break;

                                default:
                                    break;
                            }

                            Console.Write("Wich room do you want to book : ");
                            int numberOfRoom = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Login to continue");
                            //Metod reservation av rum 



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
                                Console.WriteLine("New user");
                                Console.WriteLine("Please, fill in the fields below");
                                GetNames(firstName, lastName);
                                CreateAccount(firstName, lastName, guestOrStaff);
                            }


                            hotelManager.BookRoom(numberOfRoom, 3); //// TA BORT HÅRD KOD. LÄGG TILL GUEST ID

                            //bookroom

                            break;

                        case ConsoleKey.D2:
                            // LOGIN
                            Console.Clear();
                            Console.WriteLine("[1] - Login \n[2] - Create new account");
                            Console.Write("Choice: ");

                            var logInChoice = Console.ReadKey();

                            switch (logInChoice.Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Console.WriteLine("Type in your login details");
                                    TryLogin();

                                    //se bokning
                                    //se avalible rooms - 

                                    //Choice for logged in guests?
                                    //if true // boka rummet
                                    //setroom booked

                                    break;
                                case ConsoleKey.D2: //Create new user account

                                    /* string firstName = "";
                                     string lastName = "";
                                     Guest newGuestUser = userAuthentication.AddGuestUser("Hahah", "Hihihi", "fgjkgkjfdgjk", "fsgg", "dsfsfsd", 458954895, "djsdjlkggjk", 5543, "Blä", 34546455446);

                                     Console.WriteLine(newGuestUser.UserName);
                                     newGuestUser.UserName = "hohoho";
                                     Console.WriteLine(newGuestUser.UserName);
                                     Console.WriteLine(newGuestUser.UserName);*/
                                    Console.WriteLine("CREATE NEW HOTEL USER");
                                    GetNames(firstName, lastName);
                                    CreateAccount(firstName, lastName, guestOrStaff);

                                    //meny:
                                    // visa bokningar - betala för rummet (betalt/ej betalt)
                                    //avsluta

                                    //lägg in detta i guestaccount
                                    break;

                                default:
                                    Console.WriteLine("Wrong input. You can only press 1 or 2");
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Wrong input. You can only press 1 or 2");
                            break;
                    }
                } while (true);

            }

            // FOR STAFF

            void ChoiceForStaff(HotelManager hotelManager, UserAuthentication userAuthentication)
            {
                ConsoleKeyInfo input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("STAFF");
                    Console.WriteLine("Make a choice below");
                    Console.WriteLine("[1] - Check out guest\n[2] - View all rooms\n[3] - View all Avalible rooms\n[4] - Add new staff useraccount\n[5] - Add new room \n[6] - Exit program");
                    Console.Write("Choice: ");
                    input = Console.ReadKey();

                    switch (input.Key)
                    {

                        case ConsoleKey.D1:
                            //checkout
                            int roomNumber;

                            System.Console.Write("Check out room number :");
                            roomNumber = Convert.ToInt16(Console.ReadLine());
                            PaymentNotice paymentNotice = hotelManager.CheckoutGuest(roomNumber); //// TA BORT HÅRD KOD. LÄGG TILL GUEST ID
                            if (paymentNotice == PaymentNotice.Paid)
                            {
                                Console.WriteLine("Ditt rum är redan betalt.");
                            }
                            else
                            {
                                Console.WriteLine("Kostnaden för ditt rum dras nu från ditt kreditkort.");
                                hotelManager.PayRoom(roomNumber);

                                //hotelManager.PayRoom();
                            }
                            // är det betalt så isbooked = false
                            //är den inte - dras på kortet

                            hotelManager.SetRoomAvailable(roomNumber);

                            break;

                        case ConsoleKey.D2:
                            // View all rooms
                            Console.Clear();
                            Console.WriteLine(hotelManager.ViewAllRooms());
                            Console.WriteLine("Press any key to return");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D3:
                            //View all Avalible rooms
                            string output = PrintAllAvailableRooms();
                            Console.WriteLine(output);
                            Console.Write("Press any key to return");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D4:
                            //Add staff
                            Console.Clear();
                            Console.WriteLine("ADD NEW STAFF USERACCOUNT");

                            Console.Write("Firstname: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Lastname: ");
                            string lastName = Console.ReadLine();

                            //lägg in namn och lastname.....

                            CreateAccount(firstName, lastName, guestOrStaff);

                            break;

                        case ConsoleKey.D5:
                            //add new room

                            Console.WriteLine("Add a new room to the hotel\n");

                            int squareMeters;
                            int numberOfBeds;
                            int pricePerNight;

                            //FELHANTERING

                            Console.WriteLine("Room number :");
                            roomNumber = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Square meters :");
                            squareMeters = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Number of beds :");
                            numberOfBeds = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Price per night :");
                            pricePerNight = Convert.ToInt16(Console.ReadLine());

                            hotelManager.AddNewRoom(roomNumber, squareMeters, numberOfBeds, pricePerNight);
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

                    //userAuthentication.CheckIfUsernameExist(userName); kolla username finns, när skapa användare

                    Console.Write("Password: ");

                    password = Console.ReadLine();

                    switch (guestOrStaff.Key)
                    {
                        case ConsoleKey.D2:
                        
                            isStaffUserValid = userAuthentication.TryValidateStaffUser(userName, password);
                            Console.WriteLine(isStaffUserValid);
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
                    }
                }
                while (loginTry <= 3);

                if (loginTry == 3)
                {
                    Console.WriteLine("Number of tries overriden");
                    ExitProgram();
                }

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
                        Console.WriteLine("STAFF ADDED"); ///////////////TA BORT DETTA SEN
                    }
                    else
                    {
                        GetGuestDetails(firstName, lastName, userName, password);
                        Console.WriteLine("GUEST ADDED"); ///////////////TA BORT DETTA SEN
                    }

                    Console.Write("Press any key to continue");
                    Console.ReadKey();
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
                Console.WriteLine($"GuestID: {output.GuestId}");
            }

            // PRINT AVALIBLE ROOMS

            string PrintAvailableRooms(int numberOfBeds)
            {
                string printSpecificAvailableRooms = "";
                List<Room> availableRooms = hotelManager.AddToListOfAvailableRooms(numberOfBeds);

                int index = 1;

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

                int index = 1;

                for (int i = 0; i < availableRooms.Count; i++)
                {
                    printAvailableRooms += "[" + index + "] Number of beds: " + availableRooms[i].NumberOfBeds + "\n" +
                        "Square meters: " + availableRooms[i].SquareMeters + "\n" +
                        "Price per night: " + availableRooms[i].PricePerNight + "\n\n";

                    index++;
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

        }
    }
}