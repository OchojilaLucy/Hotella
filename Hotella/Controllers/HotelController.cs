using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotella.DataBase;
using Hotella.Entities.Entities;
using Hotella.ViewModels;
using Hotella.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Hotella.Services.Services;

namespace Hotella.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelsViewModel _hotelsViewModel;
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;
        private readonly ILogger<HotelController> _logger;

        public HotelController(HotelsViewModel hotelsViewModel, IHotelService hotelService, IBookingService bookingService, ILogger<HotelController> logger) 
        {
           _hotelsViewModel = hotelsViewModel;
           _hotelService = hotelService; 
           _bookingService = bookingService;
            _logger = logger;

        }
        public IActionResult HomePageDisplay()
        {
            var hotelsViewModel = new HotelsViewModel
            {
                MostPickedHotels = _hotelService.GetHotelsByFeature("Most Picked"),
                HotelsWithBackyard = _hotelService.GetHotelsByFeature("BackYard"),
                HotelsWithSwimmingPool = _hotelService.GetHotelsByFeature("Swimming Pool"),
                HotelsWithKitchen = _hotelService.GetHotelsByFeature("Kitchen")
            };

            return View(hotelsViewModel);
        }

        public IActionResult HotelsDisplay()
        {
            var hotels = _hotelService.GetHotels(); // Ensure this list is populated
            _logger.LogInformation($"Retrieved {hotels.Count} hotels from the service.");

            var hotelsViewModel = new HotelsViewModel
            {
                Hotels = hotels
            };

            return View(hotelsViewModel);
        }

        public IActionResult HotelDetails(string hotelName, int nights = 1)
        {
            var hotel = _hotelService.GetHotel(hotelName);
            
            if (hotel == null)
            {
                return NotFound(); // Handle case where hotel doesn't exist
            }
            var checkInDate = DateTime.Today;
            var checkOutDate = _bookingService.CalculateCheckOutDate(checkInDate, nights);
            var totalPrice = _bookingService.CalculateTotalPrice(hotel.Price, nights);

            var hotelsViewModel = new HotelsViewModel(hotel); // Use the constructor to populate the view model

            return View(hotelsViewModel);
        }





        public string BrowseBy()
        {
            return "Browse by Information.";
        }
        public string Stories()
        {
            return "Stories Information";
        }
        public string Agents()
        {
            return "Agents Information";
        }

    }
}
