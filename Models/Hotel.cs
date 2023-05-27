using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XYZHotelManagementSystem.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        [Required]
        public string? HotelName { get; set; }

        [Required]
        public int TotalRooms { get; set; }

        [Required]
        public string? Location { get; set; }

        public ICollection<Room>? Rooms { get; set; }

        public ICollection<Booking>? hotelBookings { get; set; }
    }
}
