using System.Collections.Generic;


namespace HotelClassLibrary
{
    public class HotelManager
    {
        List<Booking> bookingsList = new List<Booking>();
        List<Room> allRoomsList = new List<Room>();
        List<Room> availableRoomsList = new List<Room>();

        private int bookingCounter = 0;

        public void BookRoom(int roomIndexNumber, int guestId)
        {
            int roomId = 0;
            List<Room> availableRooms = AddToListOfAvailableRooms();
            for (int i = 0; i < availableRooms.Count; i++)
            {
                roomId = availableRoomsList[roomIndexNumber -1].RoomNumber;
            }
            Booking newBooking = new Booking(bookingCounter + 1, roomId, guestId);
            bookingsList.Add(newBooking);
            SetRoomBooked(roomId);
        }

        public List<Room> AddToListOfAvailableRooms()
        {
            availableRoomsList.Clear();

            foreach (Room room in allRoomsList)
            {
                if (room.IsBooked == false)
                {
                    availableRoomsList.Add(room);
                }
            }
            return availableRoomsList;
        }

        public List<Room> AddToListOfAvailableRooms(int numberOfBeds)
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

        private void SetRoomAvailable(int roomNumber)
        {
            foreach (Room room in allRoomsList)
            {
                if (roomNumber == room.RoomNumber)
                {
                    room.IsBooked = false;
                }
            }
        }
        //PaymentNotice är tänkt att användas i vidare utbyggnad av programmet.
        public PaymentNotice CheckoutGuest(int roomNumber)
        {
            PaymentNotice paymentNotice = PaymentNotice.NotPaid;
            foreach (Booking booking in bookingsList)
            {

                if (roomNumber == booking.RoomNumber)
                {
                    SetRoomAvailable(booking.RoomNumber);

                    if (booking.IsPaid == true)
                    {
                        paymentNotice = PaymentNotice.Paid;
                    }
                }
            }
            AddToListOfAvailableRooms();
            return paymentNotice;
        }

        //Planerad att användas i utökad version.
        public void PayRoom(int roomNumber)
        {
            foreach (Booking booking in bookingsList)
            {
                if (booking.RoomNumber == roomNumber)
                {
                    booking.IsPaid = true;
                }
            }
        }

        public Booking GetGuestBooking(int bookingId)
        {
            Booking guestBooking = new Booking();

            foreach (Booking booking in bookingsList)
            {
                if (booking.BookingId == bookingId)
                {
                    guestBooking = booking;
                }
            }
            return guestBooking;
        }


        public void AddNewRoom(int roomNumber, int squareMeters, int numberOfBeds, int pricePerNight)
        {
            Room newRoom = new Room(roomNumber, squareMeters, numberOfBeds, pricePerNight);

            allRoomsList.Add(newRoom);
        }

        //Skicka tillbaka en string, skicka tillbaka listan, eller
        //göra en helt ny lista som tar satan från första och sedan
        //returneras?
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
      
        
        //Tänkt för vidare utbyggnad av programmet...
        public Booking ViewBookedRoom(int guestId)
        {
            Booking newBooking = new Booking();

            foreach (Booking booking in bookingsList)
            {
                if (booking.GuestId == guestId)
                {
                    newBooking = new Booking(booking.BookingId, booking.RoomNumber, booking.GuestId);
                    return newBooking;
                }
            }
            return newBooking;
        }

        public bool IsBooked(int roomNumber)
        {
            bool booked = false;

            foreach (Room room in allRoomsList)
            {
                if (room.RoomNumber == roomNumber)
                {
                    if (room.IsBooked == true)
                    {
                        booked = true;
                    }
                }
            }
            return booked;
        }

        public bool CheckIfRoomExists(int tryNumber)
        {
            bool roomExists = false;

            foreach (Room room in allRoomsList)
            {
                if (room.RoomNumber == tryNumber)
                {
                    roomExists = true;
                }
            }
            return roomExists;
        }

    }

    //PaymentNotice är tänkt att användas i vidare utbyggnad av programmet.
    public enum PaymentNotice
    {
        Paid = 0,
        NotPaid = 1
    }

}