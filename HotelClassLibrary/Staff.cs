namespace HotelClassLibrary
{
    class Staff : User
    {
        public int StaffId { get; set; }

        public Staff(string firstName, string lastName, string userName, string password, int staffId)
        : base(firstName, lastName, userName, password)
        {
            this.StaffId = staffId;
        }
    }
}