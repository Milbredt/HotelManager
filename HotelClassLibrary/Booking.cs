namespace HotelClassLibrary
{
    class Booking
    {
        
        public int BookingId { get; set;}
        public int RoomNumber { get; set;}
        public int GuestId { get; set;}
        public bool IsPaid { get; set;}

        public Booking(int bookingId, int roomId, int guestId)
        {
            BookingId = bookingId;
            RoomNumber = roomId;
            GuestId = guestId;
            IsPaid = false;
        }
    }
}