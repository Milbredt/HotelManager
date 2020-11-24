namespace HotelClassLibrary 
{
    public class Guest : User 
    
    {
        public int GuestId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public long CreditCardNumber { get; set; }

        public Guest (string firstName, string lastName, string userName, string password, int guestId, string email, long phonenumber, string streetaddress, int postalcode, string city, long creditCardNumber) 
        : base (firstName, lastName, userName, password)
        {
            this.GuestId = guestId;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.StreetAddress = streetaddress;
            this.PostalCode = postalcode;
            this.City = city;
            this.CreditCardNumber = creditCardNumber;
        }


    }
}