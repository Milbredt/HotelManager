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
            userAuthentication.AddStaffUser("username", "password", "firstname", "lastname");

            while (true)
            {
                Console.WriteLine("Welcome to hotel Push n Pull");
                Console.WriteLine("Make a choice");
                Console.WriteLine("Press [1]: Staff");
                Console.WriteLine("Press [2]: Guest");
                Console.WriteLine("Press [3]: Exit");
                Console.Write("Choice: ");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1: //Staff Login
                        Console.Clear();
                        Console.WriteLine("\nStaff login");
                        TryLogin();
                        ChoiceForStaff(hotelManager, userAuthentication);
                        break;

                    case ConsoleKey.D2: //Guest login
                        Console.Clear();
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

                            Console.Write("We have rooms for 1-6 persons. For how many persons in the room? : ");
                            int numberOfBeds = Convert.ToInt16(Console.ReadLine());

                            string rooms = PrintAvailableRooms(numberOfBeds); // SKRIVS EJ UT. VAD FEL???????????????????????????????????????????
                            Console.WriteLine(rooms);

                            //ändra bäddar
                            //avsluta
                            //boka ett rum
                            Console.WriteLine("Wich room do you want to book?");
                            Console.Write("Choose the number of the room you want to book : ");
                            int numberOfRooms = Convert.ToInt16(Console.ReadLine());
                            //Metod reservation av rum 


                            break;

                        case ConsoleKey.D2:
                            // LOGIN
                            Console.WriteLine("[1] - Login \n[2] - Create new account");

                            var logInChoice = Console.ReadKey();

                            switch (logInChoice.Key)
                            {
                                case ConsoleKey.D1:
                                    TryLogin();
                                    //Choice for logged in guests?
                                    //if true // boka rummet
                                    //setroom booked

                                    break;
                                case ConsoleKey.D2:
                                    //userAuthentication.AddGuestUser();
                                    Console.WriteLine("CREATE NEW HOTEL USER");


                                    Console.Write("Firstname: ");
                                    string firstName = Console.ReadLine();
                                    // if kan inte vara noll
                                    Console.Write("Lastname: ");
                                    string lastName = Console.ReadLine();
                                    string user = "Guest"; //// GÖR OM GÖR SNYGG
                                    CreateAccount(firstName, lastName, user);

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
                            hotelManager.CheckIfRoomIsPaid(roomNumber);

                            // är det betalt så isbooked = false
                            //är den inte - dras på kortet


                            hotelManager.CheckoutGuest(roomNumber);
                            hotelManager.SetRoomAvailable(roomNumber);

                            break;

                        case ConsoleKey.D2:
                            // View all rooms
                            Console.Clear();
                            Console.WriteLine(hotelManager.ViewAllRooms());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.D3:
                            //View all Avalible rooms

                            System.Console.WriteLine();
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
                            string user = "staff";
                            CreateAccount(firstName, lastName, user);


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

                        case ConsoleKey.Escape:      // Återgå till main menu
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
                    userAuthentication.TryValidateGuestUser(userName, password);
                    userAuthentication.TryValidateStaffUser(userName, password);
                    isUserValid = userAuthentication.TryValidateGuestUser(userName, password);
                    isUserValid = userAuthentication.TryValidateStaffUser(userName, password);

                    if (isUserValid == true)
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

            void CreateAccount(string firstName, string lastName, string user)
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
                            Console.ReadKey();
                        }

                        else if (isUserExisting == true)
                        {
                            Console.WriteLine("Username already exists");
                            Console.Write("Press any key to do another try");
                            Console.ReadKey();
                        }

                    } while (userName.Length < 6 || userName.Length > 16 && isUserExisting == true);

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

                    if (user == "staff")
                    {
                        userAuthentication.AddStaffUser(userName, password, firstName, lastName);
                    }
                    else
                    {
                        GetGuestDetails(firstName, lastName, userName, password);
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
                int postalCode = Convert.ToInt16(Console.ReadLine());//TRY CATCH
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("Creditcard number: ");
                int creditCardNumber = Convert.ToInt32(Console.ReadLine()); //TRY CATCH
                string output = userAuthentication.AddGuestUser(firstName, lastName, userName, password, email, phoneNumber, streetAddress, postalCode, city, creditCardNumber);
                Console.WriteLine(output);
            }



            // PRINT AVALIBLE ROOMS

            string PrintAvailableRooms(int numberOfBeds)
            {
                string printAvailableRooms = "";
                List<Room> availableRooms = hotelManager.CreateListOfAvailableRooms(numberOfBeds);

                int index = 1;

                for (int i = 1; i < availableRooms.Count + 1; i++)
                {
                    printAvailableRooms += "Number of beds: " + availableRooms[i].NumberOfBeds + "\n" +
                        "Square meters: " + availableRooms[i].SquareMeters + "\n" +
                        "Price per night: " + availableRooms[i].PricePerNight + "\n";

                    index++;
                }
                return printAvailableRooms;
            }

        }
    }
}


