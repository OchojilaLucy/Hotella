using System;
using System.ComponentModel.DataAnnotations;

namespace Hotella.ViewModels
{
    public class BookingViewModel
    {
        public int HotelId { get; set; }

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
