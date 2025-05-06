using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotella.Entities.Entities;
using Hotella.Entities.Dtos;

namespace Hotella.Services.Interfaces
{
    public interface IBookingService
    {
        
        
        void CreateBooking(BookingCreationDto bookingCreationDto);
        void UpdateBooking(BookingUpdateDto bookingUpdateDto);
        List<Booking> GetBookingsByTravelerId(int travelerId);
        Booking GetBookingById(int bookingId);
        void DeleteBooking(int bookingId);
        decimal CalculateTotalPrice(decimal pricePerNight, int numberOfNights);
        DateTime CalculateCheckOutDate(DateTime checkInDate, int numberOfNights);
    }
}
