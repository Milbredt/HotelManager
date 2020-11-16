namespace HotelClassLibrary
{
    class Guest : User
    {
        public int GuestId { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public int CreditCardNumber { get; set; }



    }
}