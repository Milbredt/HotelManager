using System;
using System.Collections.Generic;
using System.Threading;
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
            hotelManager.BookRoom(1, 1); // HÅRDKOD KS

            while (true)
            {
                Console.WriteLine("\n\nWelcome to hotel Push n Pull");
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

                    case ConsoleKey.D2: //Staff Login
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

            //CHOICE FOR GUEST
            void ChoiceForGuest(HotelManager hotelManager)
            {
                ConsoleKeyInfo bookingMenuChoice;
                Console.Clear();
                Console.WriteLine("Welcome guest");

                bool getNumberOfBedsLoop = true;
                do
                {
                    int numberOfBeds = GetNumberOfBeds();

                    Console.Clear();
                    Console.WriteLine("Rooms that are avalible for you\n");

                    do
                    {
                        string rooms = PrintAvailableRooms(numberOfBeds);
                        Console.WriteLine(rooms);

                        Console.WriteLine("[1] - Book a room\n[2] - Change number of beds \n[Esc] - Return to main menu");
                        Console.Write("Choice: ");
                        bookingMenuChoice = Console.ReadKey();

                        switch (bookingMenuChoice.Key)
                        {
                            case ConsoleKey.D1:
                                Console.WriteLine("\n- Book room -\n");

                                int chosenRoomNumber = GetRoomChoice(hotelManager.AddToListOfAvailableRooms(numberOfBeds));
                                Console.WriteLine("\nLogin or create a new account to continue\n");

                                Console.WriteLine("[1] - Login \n[2] - Create new account");
                                Console.Write("Choice: ");
                                ConsoleKeyInfo inputKey = Console.ReadKey();

                                switch (inputKey.Key)
                                {
                                    case ConsoleKey.D1:
                                        TryLogin();
                                        break;

                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine("New user");
                                        Console.WriteLine("Please, fill in the fields below\n");
                                        SetFirstName();
                                        SetLastName();
                                        CreateAccount(firstName, lastName, guestOrStaff);
                                        break;

                                    default:
                                        Console.WriteLine("Wrong input.Make a chioce between [1] or [2]");
                                        break;
                                }

                                hotelManager.BookRoom(chosenRoomNumber, guestId);
                                Console.WriteLine("\nYour booking is confirmed!\n");
                                Console.Write("Press any key to exit");
                                Console.ReadKey();
                                ExitProgram();
                                break;

                            case ConsoleKey.D2:
                                //Breakar loop och återgår till välja antalet bäddar
                                break;

                            case ConsoleKey.Escape:
                                getNumberOfBedsLoop = false;
                                break;

                            default:
                                Console.WriteLine("\nWrong input. You can only press [1], [2] or [Esc]");
                                Console.Write("Press any key to continue");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    } while (true);

                } while (getNumberOfBedsLoop);
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
                    Console.WriteLine("[1] - Check out guest\n[2] - View all rooms\n[3] - View all available rooms\n[4] - Add new staff useraccount\n[5] - Add new room \n[6] - Exit program");
                    Console.Write("Choice: ");
                    input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:

                            StaffCheckOut();
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
                            string allAvailableRooms = PrintAllAvailableRooms();
                            Console.WriteLine(allAvailableRooms);
                            Console.Write("Press any key to return");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D4:
                            //Add staff
                            Console.Clear();
                            Console.WriteLine("ADD NEW STAFF USERACCOUNT\n");
                            SetFirstName();
                            SetLastName();
                            CreateAccount(firstName, lastName, guestOrStaff);
                            break;

                        case ConsoleKey.D5:
                            //add new room
                            Console.Clear();
                            SetRoomDetails();
                            break;

                        case ConsoleKey.D6:
                            //Exit
                            ExitProgram();
                            break;

                        case ConsoleKey.Escape: // Återgå till main menu
                            break;

                        default:
                            Console.WriteLine("Wrong input. You can only make a choice between 1-6");
                            Console.Write("Press any key to continue");
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
                        Console.Write("Login succeded");
                        Thread.Sleep(1500);
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
                string password;
                string userName;

                do
                {
                    userName = GetUserName();
                    password = GetPassword();

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
                string email = SetEmail();
                long phoneNumber = SetPhoneNumber();
                string streetAddress = SetStreetAddress();
                int postalCode = SetPostalCode();
                string city = SetCity();
                long creditCardNumber = SetCreditcardNumber();

                var output = userAuthentication.AddGuestUser(firstName, lastName, userName, password, email, phoneNumber, streetAddress, postalCode, city, creditCardNumber);

                Console.Clear();
                Console.WriteLine("New account created!\n");
                Console.WriteLine($"Your guest id is: {output.GuestId}. \nPlease save your guest id for further use in the booking system.");
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

            // void CheckUserInput(string input)
            // {
            //     do
            //     {

            //         if (string.IsNullOrEmpty(input))
            //         {
            //             Console.WriteLine("You must fill in something");
            //             Console.Write("Press any key to do another try");
            //             Console.ReadKey();
            //         }
            //         else
            //         {
            //             break;
            //         }
            //     } while (true);
            // }
        

            void SetFirstName()
            {
                do
                {
                    Console.Write("Firstname: ");
                    firstName = Console.ReadLine();//NullOrEmpty.ObjectDisposedException................................
                   if (string.IsNullOrEmpty(firstName))
                   {
                       Console.WriteLine("You must fill in a firstname");
                        Console.Write("Press any key to do another try");
                        Console.ReadKey();
                   }
                   else
                   {
                       break;
                   }
                } while (true);
            }

            void SetLastName()
            {
                do
                {
                    Console.Write("Lastname: ");
                    lastName = Console.ReadLine();//NullOrEmpty.ObjectDisposedException................................
                   if (string.IsNullOrEmpty(lastName))
                   {
                       Console.WriteLine("You must fill in a lastname");
                        Console.Write("Press any key to do another try");
                        Console.ReadKey();
                   }
                   else
                   {
                       break;
                   }
                } while (true);
            }

            string GetUserName()
            {
                string userName;
                bool isUserExisting;
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

                return userName;
            }

            string GetPassword()
            {
                string password;
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

                return password;
            }

            void ExitProgram()
            {
                Console.WriteLine("\nProgram exits");
                Environment.Exit(0);
            }

            int GetNumberOfBeds()
            {
                int numberOfBeds = 0;

                do
                {
                    Console.Clear();
                    Console.Write("We have rooms for 1-6 persons. \nHow many persons? : ");

                    try
                    {
                        numberOfBeds = Convert.ToInt16(Console.ReadLine());
                        if (numberOfBeds > 0 && numberOfBeds < 7)
                        {
                            break;
                        }
                        else if (numberOfBeds > 6 || numberOfBeds <= 0)
                        {
                            Console.WriteLine("You may only choose a number between 1 and 6.");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You may only choose a number between 1 and 6.");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }

                } while (true);

                return numberOfBeds;
            }


            int GetRoomChoice(List<Room> availableRooms)
            {
                int roomChoice = 0;

                do
                {
                    Console.Write("Which room do you want to book : ");
                    try
                    {
                        roomChoice = Convert.ToInt32(Console.ReadLine());

                        {
                            if (roomChoice < 0 || roomChoice > availableRooms.Count)
                            {
                                Console.WriteLine("You may only choose a room number that exists in the list of available rooms.\n");
                                Console.Write("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You may only choose a room number that exists in the list of available rooms.\n");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }

                } while (true);

                return roomChoice;
            }

            void StaffCheckOut()
            {
                int roomNumberToCheckOut = 0;
                bool isBooked = hotelManager.IsBooked(roomNumberToCheckOut);

                do
                {
                    try
                    {
                        roomNumberToCheckOut = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        System.Console.WriteLine("Wrong input. ");
                    }

                    if (isBooked == true)
                    {
                        PaymentNotice paymentNotice = hotelManager.CheckoutGuest(roomNumberToCheckOut);
                        Console.WriteLine("\nDo not forget to charge the creditcard.\n");
                        //hotelManager.PayRoom(roomNumber);
                        Console.WriteLine($"Room {roomNumberToCheckOut} is now avalible!");
                        Console.Write("Press any key to continue the check out");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The room number you entered isn't booked!");
                    }

                } while (true);
            }

            void SetRoomDetails()
            {
                Console.WriteLine("Add a new room to the hotel\n");

                int roomNumber = SetRoomNumber();
                int squareMeters = SetSquareMeters();
                int numberOfBeds = SetNumberOfBeds();
                int pricePerNight = SetPricePerNight();

                hotelManager.AddNewRoom(roomNumber, squareMeters, numberOfBeds, pricePerNight);
                Console.Write("\nRoom successfully added\nPress any key to continue");
                Console.ReadKey();
            }

            int SetRoomNumber()
            {
                bool roomExists = false;
                int roomNumber = 0;
                do
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("Room number: ");
                        try
                        {
                            roomNumber = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }
                    } while (true);

                    roomExists = hotelManager.CheckIfRoomExists(roomNumber);

                    if (roomExists == true)
                    {
                        Console.WriteLine("The room number you have chosen already exists.\nPlease choose another.\n");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else if (roomNumber <= 0)
                    {
                        Console.WriteLine("You must choose a number above 0.\n");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (roomNumber <= 0 || roomExists == true);

                return roomNumber;
            }

            int SetSquareMeters()
            {
                int squareMeters = 0;

                do
                {
                    bool sqmLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Square meters: ");
                        try
                        {
                            squareMeters = Convert.ToInt32(Console.ReadLine());
                            sqmLoop = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }
                    } while (sqmLoop);

                    if (squareMeters < 10 || squareMeters > 100)
                    {
                        Console.WriteLine("You can only type in numbers between 10 and 100\n");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (squareMeters < 10 || squareMeters > 100);

                return squareMeters;
            }

            int SetNumberOfBeds()
            {
                int numberOfBeds = 0;
                do
                {
                    bool numberOfBedsLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Number of beds: ");
                        try
                        {
                            numberOfBeds = Convert.ToInt32(Console.ReadLine());
                            numberOfBedsLoop = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }
                    } while (numberOfBedsLoop);

                    if (numberOfBeds <= 0)
                    {
                        Console.WriteLine("You must choose a number above 0");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else if (numberOfBeds > 6)
                    {
                        Console.WriteLine("You must choose a number below 7");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (numberOfBeds < 1 || numberOfBeds > 6);

                return numberOfBeds;
            }

            int SetPricePerNight()
            {
                int pricePerNight = 0;
                do
                {
                    bool setPricePerNightLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Price per night: ");
                        try
                        {
                            pricePerNight = Convert.ToInt32(Console.ReadLine());
                            setPricePerNightLoop = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }

                    } while (setPricePerNightLoop);

                    if (pricePerNight < 1)
                    {
                        Console.WriteLine("You must set a price above 0");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (pricePerNight < 1);

                return pricePerNight;
            }

            string SetEmail()
            {
                string email = "";

                do
                {
                    Console.Clear();
                    Console.Write("Email: ");
                    email = Console.ReadLine();

                    if (string.IsNullOrEmpty(email))
                    {
                        Console.WriteLine("You must insert something as your email address!");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                return email;
            }

            string SetStreetAddress()
            {
                string streetAddress = "";

                do
                {
                    Console.Clear();
                    Console.Write("Street address: ");
                    streetAddress = Console.ReadLine();

                    if (string.IsNullOrEmpty(streetAddress))
                    {
                        Console.WriteLine("You must insert something as your street address!");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                return streetAddress;
            }

            string SetCity()
            {
                string city = "";

                do
                {
                    Console.Clear();
                    Console.Write("City: ");
                    city = Console.ReadLine();

                    if (string.IsNullOrEmpty(city))
                    {
                        Console.WriteLine("You must insert something as your City!");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                return city;
            }

            long SetPhoneNumber()
            {
                long phoneNumber = 0;
                do
                {
                    bool setPhoneNumberLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Phone number: ");
                        try
                        {
                            phoneNumber = Convert.ToInt64(Console.ReadLine());
                            setPhoneNumberLoop = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }

                    } while (setPhoneNumberLoop);

                    if (phoneNumber < 10000000000 || phoneNumber > 99999999)
                    {
                        Console.WriteLine("You must type in a valid phone number");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (phoneNumber < 10000000000 || phoneNumber > 99999999);

                return phoneNumber;
            }

            int SetPostalCode()
            {
                int postalCode = 0;
                do
                {
                    bool setPostalCodeLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Postal code: ");
                        try
                        {
                            postalCode = Convert.ToInt32(Console.ReadLine());
                            setPostalCodeLoop = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }

                    } while (setPostalCodeLoop);

                    if (postalCode < 10000 || postalCode > 9999)
                    {
                        Console.WriteLine("You must type in 5 digit number");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (postalCode < 10000 || postalCode > 9999);

                return postalCode;
            }

            long SetCreditcardNumber()
            {
                long creditcardNumber = 0;
                do
                {
                    bool setcreditCardNumber = true;
                    do
                    {
                        Console.Clear();
                        Console.Write("Creditcard number: ");
                        try
                        {
                            creditcardNumber = Convert.ToInt64(Console.ReadLine());
                            setcreditCardNumber = false;
                        }
                        catch
                        {
                            Console.WriteLine("You can only type in numbers");
                            Console.Write("Press any key to continue");
                            Console.ReadKey();
                        }

                    } while (setcreditCardNumber);

                    if (creditcardNumber < 10000000000000000 || creditcardNumber > 999999999999999)
                    {
                        Console.WriteLine("You must type in a valid creditcard number");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (creditcardNumber < 10000000000000000 || creditcardNumber > 999999999999999);

                return creditcardNumber;
            }
        }
    }
}
