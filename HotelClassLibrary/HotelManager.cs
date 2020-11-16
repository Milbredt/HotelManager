using System.Collections.Generic;


namespace HotelClassLibrary
{
    public class HotelManager
    {
        public Dictionary<int, Room> rooms = new Dictionary<int, Room>();
        public Dictionary<int, int> staff = new Dictionary<int, int>();
        public Dictionary<int, int> users = new Dictionary<int, int>();
        List<Booking> bookingList = new List<Booking>();
        List<Room> roomList = new List<Room>();


        public void BookRoom(int bookingId, int roomId, int guestId)
        {
            //Book
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
            roomList.Add(newRoom);
            roomList.Add(newRoom1);
            roomList.Add(newRoom2);
            roomList.Add(newRoom3);
            roomList.Add(newRoom4);
            roomList.Add(newRoom5);
            roomList.Add(newRoom6);
            roomList.Add(newRoom7);
            roomList.Add(newRoom8);
            roomList.Add(newRoom9);

            //roomNumber, squareMeters, numberOfBeds, pricePerNight
        }

        public string ViewAllRooms()
        {
            string roomDescriptions = "";

            foreach (Room room in roomList)
            {
                roomDescriptions += "Number of beds: " + room.NumberOfBeds + "\n" +
                "Square meters: " + room.SquareMeters + "\n" +
                "Price per night: " + room.PricePerNight + "\n";
            }
            return roomDescriptions;
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