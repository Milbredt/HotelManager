namespace HotelClassLibrary
{
    class Booking
    {
        
        public int BookingId { get; set;}
        public int RoomId { get; set;}
        public int GuestId { get; set;}
        public bool IsPaid { get; set;}

        public Booking(int bookingId, int roomId, int guestId)
        {
            BookingId = bookingId;
            RoomId = roomId;
            GuestId = guestId;
            IsPaid = false;
        }
    }
}