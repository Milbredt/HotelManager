using System.Collections.Generic;


namespace HotelClassLibrary
{
    public class HotelManager
    {
        
        public Dictionary<int, int> staff = new Dictionary<int, int>();
        public Dictionary<int, int> users = new Dictionary<int, int>();
        List<Booking> bookingsList = new List<Booking>();
        List<Room> allRoomsList = new List<Room>();
        List<Room> availableRoomsList = new List<Room>();
        List<Guest> guestList = new List<Guest>();
        
        private int bookingCounter = 0;

        public void BookRoom(int roomId, int guestId)
        {
            Booking newBooking = new Booking(bookingCounter + 1, roomId, guestId);

            SetRoomBooked(roomId);
        }

        private void SetRoomBooked(int roomNumber)
        {
            foreach (Room room in allRoomsList)
            {
                if (roomNumber == room.RoomNumber)
                {
                    room.IsBooked = true;
                }
            }
        }

        public void SetRoomAvailable(int roomNumber)
        {
            foreach (Room room in allRoomsList)
            {
                if (roomNumber == room.RoomNumber)
                {
                    room.IsBooked = false;
                }
            }
        }

        public string CheckoutGuest (int roomNumber)
        {
            
            string paymentNotice = "";
            foreach (Booking booking in bookingsList)
            {
                if (roomNumber == booking.RoomNumber)
                {
                    SetRoomAvailable(booking.RoomNumber);

                    if (booking.IsPaid == true)
                    {
                        return paymentNotice = "Your stay has already been paid. Thank you and welcome back!";
                    }
                    else
                    {
                        return paymentNotice = "The fee will be charged from your creditcard. Thank you and welcome back";
                    }
                }
            }
            return paymentNotice;
        }

        public bool PayRoom(int roomNumber, int guestId, int creditcard)
        {
            bool roomPaid = false;

            foreach (Booking booking in bookingsList)
            {
                if (booking.RoomNumber == roomNumber && booking.GuestId == guestId)
                {
                    foreach (Guest guest in guestList)
                    {
                        if (guest.CreditCardNumber == creditcard && guest.GuestId == booking.GuestId)
                        {
                            if (booking.IsPaid == true)
                            {
                                roomPaid = true;
                            }
                        }
                    }
                }
            }            
            return roomPaid;
        }

        public bool CheckIfRoomIsPaid(int roomnumber)
        {
            //if (?? == true)
            //{
            //    return true;
            //}
            //return false;
            return true;
        }



        public void AddNewRoom(int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
        {
            Room newRoom = new Room(roomNumber, squareMeters, numberOfBeds, pricePerNight);

            
            allRoomsList.Add(newRoom);

        }

        


        public string ViewAllRooms()
        {
            string roomDescriptions = "";

            foreach (Room room in allRoomsList)
            {
                roomDescriptions += room.RoomNumber + "\n" +
                "Number of beds: " + room.NumberOfBeds + "\n" +
                "Square meters: " + room.SquareMeters + "\n" +
                "Price per night: " + room.PricePerNight + "\n\n";
            }
            return roomDescriptions;
        }

        public List<Room> CreateListOfAvailableRooms(int numberOfBeds)
        {
            availableRoomsList.Clear();

            foreach (Room room in allRoomsList)
            {
                if (room.IsBooked == false && room.NumberOfBeds == numberOfBeds)
                {
                    availableRoomsList.Add(room);
                }
            }


            return availableRoomsList;
        }

    }
}