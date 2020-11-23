using System.Collections.Generic;


namespace HotelClassLibrary
{
    public class HotelManager
    {
        List<Booking> bookingsList = new List<Booking>();
        List<Room> allRoomsList = new List<Room>();
        List<Room> availableRoomsList = new List<Room>();

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
            return paymentNotice;
        }

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

    

    }
        public enum PaymentNotice
        {
            Paid = 0,
            NotPaid = 1
        }
}