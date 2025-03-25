namespace HotelBookingAPI.Data.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string FeaturedImage { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
