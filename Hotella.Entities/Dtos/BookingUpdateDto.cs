using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotella.Entities.Dtos
{
    public class BookingUpdateDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int TravelerId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; } = DateTime.Today.AddDays(1);

        public decimal PricePerNight { get; set; }
        public int NumberOfNights => (CheckOutDate - CheckInDate).Days;
        public decimal TotalPrice => NumberOfNights * PricePerNight;
    }
}
