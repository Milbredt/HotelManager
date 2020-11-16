namespace HotelClassLibrary
{

    abstract class User
    {
        public User(string firstName, string lastName, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.UserName = userName;
            this.Password = password;
        }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}