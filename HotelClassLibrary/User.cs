namespace HotelClassLibrary
{
    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Konstruktor
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

         public override string ToString()
         {
             return $"Username: {UserName}  \n Password {Password}";
         }
    }
}