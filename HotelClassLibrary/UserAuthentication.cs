using System.Collections.Generic;

namespace HotelClassLibrary
{

    public class UserAuthentication
    {
        List<User> listOfUsers = new List<User>(); // GÖR OM TILL DICTIONARY

        public string AddUser(string userName, string password) // HA KVAR AddStaffUser
        {
            foreach (User user in listOfUsers)  // Kod som gör att det inte går att lägga till en användare med samma användarnamn
            {
                if (user.UserName == userName)

                    return "This username is already taken";
            }
            User newUser = new User(userName, password);
            listOfUsers.Add(newUser);
            return $"Adding this user suceeded! \n\nUsername: {userName} \n Password: {password}";
        }       
        
        public bool TryValidateUser(string userName, string password)
        {
            foreach (User user in listOfUsers)
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