namespace HotelBookingAPI.Data.Model
{
    public class BaseClass
    {
        public int? CreatorId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
    }
}
