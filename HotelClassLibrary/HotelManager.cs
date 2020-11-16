using System.Collections.Generic;


namespace HotelClassLibrary
{
    public class HotelManager
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



        public void AddRoom(int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
        {
            Room newRoom = new Room(roomNumber, squareMeters, numberOfBeds, pricePerNight);

            rooms.Add(roomNumber, newRoom);


        }

        public void AddRoom()
        {
            Room newRoom = new Room(1, 65, 4, 2233);
            Room newRoom1 = new Room(2, 63, 3, 1933);
            Room newRoom2 = new Room(3, 62, 4, 2133);
            Room newRoom3 = new Room(4, 45, 3, 3233);
            Room newRoom4 = new Room(5, 67, 2, 2233);
            Room newRoom5 = new Room(6, 17, 2, 3233);
            Room newRoom6 = new Room(7, 14, 1, 2233);
            Room newRoom7 = new Room(8, 21, 2, 4333);
            Room newRoom8 = new Room(9, 20, 2, 2333);
            Room newRoom9 = new Room(10, 20, 1, 2133);

            //roomNumber, squareMeters, numberOfBeds, pricePerNight
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

        public List<Room> ViewAvailableRooms()
        {
            List<Room> availableRooms = new List<Room>();

            foreach (KeyValuePair<int, Room> room in rooms)
            {

                if (room.Value.IsBooked == false)
                {
                    availableRooms.Add(room.Value);
                }
            }
            return availableRooms;
        }





    }
}