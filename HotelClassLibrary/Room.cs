namespace HotelClassLibrary
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int SquareMeters { get; set; }
        public int NumberOfBeds { get; set; }
        public int PricePerNight { get; set; }
        public bool IsBooked { get; set;}

        public Room(int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
        {
            RoomNumber = roomNumber;
            SquareMeters = squareMeters;
            NumberOfBeds = numberOfBeds;
            PricePerNight = pricePerNight;
            IsBooked = false;
        }
    }
}