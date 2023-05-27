using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XYZHotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string? AvalabilityStatus { get; set; }

        public ICollection<Booking>? hotelBookings { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public string? Type { get; set; }
    }

}
