using System.Collections.Generic;

namespace HotelClassLibrary
{

    public class UserAuthentication
    {
        int staffIdCount = 0;
        Dictionary<int, Guest> dictionaryOfGuest = new Dictionary<int, Guest>();
        Dictionary<int, Staff> dictionaryOfStaff = new Dictionary<int, Staff>();

        public string AddGuestUser(string firstName, string lastName, string userName, string password, int guestId, string email, int phonenumber, string streetaddress, int postalcode, string city, int creditCardNumber) // HA KVAR AddStaffUser
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Guest> guest in dictionaryOfGuest)
            {
                if (guest.Value.UserName == userName)

                    return "This username is already taken";
            }
            Guest newGuestUser = new Guest(firstName, lastName, userName, password, guestId, email, phonenumber, streetaddress, postalcode, city, creditCardNumber);
            dictionaryOfGuest.Add(guestId, newGuestUser);
            return $"Adding this guest user suceeded! \n\nUsername: {userName} \n Password: {password}";
        }

        public string AddStaffUser(string userName, string password, string firstName, string lastName)
        {
            staffIdCount++;

            Staff newStaffUser = new Staff(firstName, lastName, userName, password, staffIdCount);
            dictionaryOfStaff.Add(staffIdCount, newStaffUser);
            return $"Adding this staff user suceeded! \n\nUsername: {userName} \n Password: {password}";


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