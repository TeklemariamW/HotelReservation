namespace Hotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}