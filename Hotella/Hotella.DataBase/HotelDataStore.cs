using Hotella.Entities.Entities;

namespace Hotella.DataBase
{
    public class HotelDataStore
    {

        public static List<Hotel> hotels = new List<Hotel>()
    {
        new Hotel
        {
            Name = "Jordan Suite",
            Features = new List<HotelFeature>
            {
                HotelFeature.WiFi, HotelFeature.BackYard,
                HotelFeature.Refrigerator, HotelFeature.Restaurant, HotelFeature.Gym,
                HotelFeature.Parking, HotelFeature.MostPicked,
                HotelFeature.Spa
            },
            City = City.Lagos,
            Price = 300,
            ImageUrl = "/images/byd/hotel4.jpeg"
        },
        new Hotel
        {
            Name = "Oregano",
            Features = new List<HotelFeature> { HotelFeature.WiFi, HotelFeature.Spa, 
                HotelFeature.MostPicked, HotelFeature.Kitchen },
            City = City.Calabar,
            Price = 200,
            ImageUrl = "/images/ktn/hotel1.jpeg"
        },
        new Hotel
        {
            Name = "Safe Haven",
            Features = new List<HotelFeature> { HotelFeature.WiFi, HotelFeature.Spa, 
                HotelFeature.Gym, HotelFeature.Restaurant, HotelFeature.SwimmingPool },
            City = City.Abuja,
            Price = 500,
            ImageUrl = "/images/sp/hotel2.jpg"
        },
        new Hotel
        {
            Name = "Vinna Vill",
            Features = new List<HotelFeature> { HotelFeature.Bathroom, HotelFeature.WiFi,
                HotelFeature.Kitchen, HotelFeature.SwimmingPool, HotelFeature.MostPicked },
            City = City.Abuja,
            Price = 400,
            ImageUrl = "/images/sp/hotel4.jpeg"
        }
    };
    }
}