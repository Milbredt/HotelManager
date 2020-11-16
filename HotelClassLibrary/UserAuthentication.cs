using System.Collections.Generic;

namespace HotelClassLibrary
{

    public class UserAuthentication
    {
       
        Dictionary<int, Guest> dictionaryOfUsers = new Dictionary<int, Guest>();
        Dictionary<int, Staff> dictionaryOfStaff = new Dictionary<int, Staff>();


        public string AddGuestUser(string userName, string password) // HA KVAR AddStaffUser
        {
            foreach (Guest guest in dictionaryOfUsers)  // Kod som gör att det inte går att lägga till en användare med samma användarnamn
            {
                if (user.UserName == userName)

                    return "This username is already taken";
            }
            Guest newGestUser = new Guest(userName, password);
            dictionaryOfUsers.Add(newGuestUser);
            return $"Adding this user suceeded! \n\nUsername: {userName} \n Password: {password}";
        }    
         public string AddStaffUser(string userName, string password) // HA KVAR AddStaffUser
        {
            foreach (Guest guest in dictionaryOfUsers)  // Kod som gör att det inte går att lägga till en användare med samma användarnamn
            {
                if (user.UserName == userName)

                    return "This username is already taken";
            }
            Guest newGestUser = new Guest(userName, password);
            dictionaryOfUsers.Add(newUser);
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