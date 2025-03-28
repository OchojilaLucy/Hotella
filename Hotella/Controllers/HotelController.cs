using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotella.DataBase;
using Hotella.Entities.Entities;
using Hotella.ViewModels;

namespace Hotella.Controllers
{
    public class HotelController : Controller
    {
        //private readonly HotelsViewModel _hotelsViewModel;
        public HotelController(HotelsViewModel hotelsViewModel) 
        {
           // _hotelsViewModel = hotelsViewModel;
        }
        public IActionResult HomePageDisplay( HotelFeature hotelFeature)
        {
            
            hotelFeature = HotelFeature.MostPicked;
           
           var hotels = DataBase.HotelDataStore.hotels.Where(h => h.Features.Contains(hotelFeature)).ToList();

            var hotelsViewModel = new HotelsViewModel
            {
                Hotels = hotels // Directly assigning the entity list
            };
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
