using System.Collections.Generic;
using System.IO;

namespace HotelClassLibrary
{
    class HotelManager
    {
        public Dictionary<int, Room> rooms = new Dictionary<int, Room>();
        public Dictionary<int, int> staff = new Dictionary<int, int>();
        public Dictionary<int, int> users = new Dictionary<int, int>();


        public void CheckInGuest()
        {

        }

        public void CheckOutGuest()
        {

        }

        public void UpdateRoomStatus()
        {

        }

        public void PayRoom()
        {

        }

        public void ViewAllRooms()
        {
            string roomDescriptions = "";

            foreach (KeyValuePair<int, Room> room in rooms)
            {
                roomDescriptions += "Number of beds: " + room.Value.NumberOfBeds + "\n" + 
                "Square meters: " + room.Value.SquareMeters + "\n" + 
                "Price per night: " + room.Value.PricePerNight + "\n";
            }
        }

        public void AddRoom(int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
        {
            Room newRoom = new Room(roomNumber, squareMeters, numberOfBeds, pricePerNight);

            rooms.Add(roomNumber, newRoom);


        }





    }
}