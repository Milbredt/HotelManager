using System.Collections.Generic;

namespace HotelClassLibrary
{

    public class UserAuthentication
    {
        int staffIdCount = 0;
        int guestIdCount = 0;
        Dictionary<int, Guest> dictionaryOfGuest = new Dictionary<int, Guest>();
        Dictionary<int, Staff> dictionaryOfStaff = new Dictionary<int, Staff>();

        public Guest AddGuestUser(string firstName, string lastName, string userName, string password, string email, int phoneNumber, string streetAddress, int postalCode, string city, long creditCardNumber) // HA KVAR AddStaffUser
        {
            guestIdCount++;
            
            Guest guestUser = new Guest(firstName, lastName, userName, password, guestIdCount, email, phoneNumber, streetAddress, postalCode, city, creditCardNumber);
            Guest guestUser2 = new Guest(firstName, lastName, userName, password, guestIdCount, email, phoneNumber, streetAddress, postalCode, city, creditCardNumber);
            dictionaryOfGuest.Add(guestIdCount, guestUser);
            Guest newGuestUser = guestUser;
            System.Console.WriteLine(newGuestUser.FirstName);
            return guestUser2;
        }
        public string AddStaffUser(string userName, string password, string firstName, string lastName)
        {
            staffIdCount++;

            Staff newStaffUser = new Staff(firstName, lastName, userName, password, staffIdCount);
            dictionaryOfStaff.Add(staffIdCount, newStaffUser);
            return $"Adding this staff user suceeded! \n\nUsername: {userName} \nPassword: {password} \nStaff id: {staffIdCount}";
            
        }

        public bool CheckIfUsernameExist(string userName)
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Staff> staff in dictionaryOfStaff)
            {
                if (staff.Value.UserName == userName)

                    return true;
            }
            foreach (KeyValuePair<int, HotelClassLibrary.Guest> guest in dictionaryOfGuest)
            {
                if (guest.Value.UserName == userName)

                    return true;
            }
            return false;
        }

        public bool TryValidateGuestUser(string userName, string password)
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Guest> guest in dictionaryOfGuest)
            {
                if (guest.Value.UserName == userName && guest.Value.Password == password)

                    return true;
            }
            return false;
        }

        public bool TryValidateStaffUser(string userName, string password)
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Staff> staff in dictionaryOfStaff)
            {
                if (staff.Value.UserName == userName && staff.Value.Password == password)

                    return true;
            }
            return false;
        }

        /* 
         public string RemoveUser(string userName) // HA KVAR?????????
         {
             foreach (var user in listOfUsers)
             {
                 if (user.UserName == userName)
                 {
                     listOfUsers.RemoveAll(user => user.UserName == userName);
                     return "Användaren " + userName + " är nu borttagen!\nTryck på en valfri tangent för att fortsätta";
                 }
             }
             return "Felaktig inmatning. Användaren finns ej.";
         }*/
    }
}