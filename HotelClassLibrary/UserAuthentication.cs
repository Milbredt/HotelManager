using System.Collections.Generic;


namespace HotelClassLibrary
{

    public class UserAuthentication
    {

        Dictionary<int, Guest> dictionaryOfUsers = new Dictionary<int, Guest>();
        Dictionary<int, Staff> dictionaryOfStaff = new Dictionary<int, Staff>();

     


        public string AddGuestUser(string firstName, string lastName, string userName, string password, int guestId, string email, int phonenumber, string streetaddress, int postalcode, string city, int creditCardNumber) // HA KVAR AddStaffUser
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Guest> entry in dictionaryOfUsers) // Kod som gör att det inte går att lägga till en användare med samma användarnamn
            {
                if (user.UserName == userName)

                    return "This username is already taken";
            }
            Guest newGuestUser = new Guest(firstName, lastName, userName, password, guestId, email, phonenumber, streetaddress, postalcode, city, creditCardNumber);
            dictionaryOfUsers.Add(guestId, newGuestUser);
            return $"Adding this user suceeded! \n\nUsername: {userName} \n Password: {password}";
        }
        public string AddStaffUser(string userName, string password) // HA KVAR AddStaffUser
        {
            foreach (KeyValuePair<int, HotelClassLibrary.Staff> entry in dictionaryOfStaff) // Kod som gör att det inte går att lägga till en användare med samma användarnamn
            {
                if (staff.UserName == userName)

                    return "This username is already taken";
            }
            Staff newStaffUser = new Staff(firstName, lastName, userName, password, staffId);
            dictionaryOfUsers.Add(staff.staffId, newStaffUser);
            return $"Adding this user suceeded! \n\nUsername: {userName} \n Password: {password}";
        }

        public bool TryValidateUser(string userName, string password)
        {
            foreach (User user in dictionaryOfUsers)
            {
                if (user.UserName == userName && user.Password == password)

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