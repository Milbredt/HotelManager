namespace HotelClassLibrary
{
    class Room
{
    public int RoomNumber {get; set;}
    public int SquareMeters {get; set;}
    public int NumberOfBeds {get; set;}
    public int PricePerNight {get; set;}

    public Room (int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
    {
        roomNumber = RoomNumber;
        squareMeters = SquareMeters;
        numberOfBeds = NumberOfBeds;
        pricePerNight = PricePerNight;
    }
}
}