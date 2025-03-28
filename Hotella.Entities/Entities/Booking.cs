﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotella.Entities.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int TravelerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
