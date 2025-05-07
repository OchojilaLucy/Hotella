using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotella.DataBase;
using Hotella.Entities.Entities;
using Hotella.ViewModels;
using Hotella.Services.Interfaces;

namespace Hotella.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelsViewModel _hotelsViewModel;
        private readonly IHotelService _hotelService;
        public HotelController(HotelsViewModel hotelsViewModel, IHotelService hotelService) 
        {
           _hotelsViewModel = hotelsViewModel;
           _hotelService = hotelService;
        }
        public IActionResult HomePageDisplay()
        {
            var hotelsViewModel = new HotelsViewModel
            {
                MostPickedHotels = _hotelService.GetHotelsByFeature(HotelFeature.MostPicked),
                HotelsWithBackyard = _hotelService.GetHotelsByFeature(HotelFeature.BackYard),
                HotelsWithSwimmingPool = _hotelService.GetHotelsByFeature(HotelFeature.SwimmingPool),
                HotelsWithKitchen = _hotelService.GetHotelsByFeature(HotelFeature.Kitchen)
            };

            return View(hotelsViewModel);
        }

        public IActionResult HotelsDisplay()
        {
            var hotelsViewModel = new HotelsViewModel
            {
                Hotels = _hotelService.GetHotels() // Ensure this list is populated
            };
            return View(hotelsViewModel);
        }
        public IActionResult HotelDetails(string hotelName)
        {
            var hotel = _hotelService.SelectHotel(hotelName);

            return View(hotel);
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
