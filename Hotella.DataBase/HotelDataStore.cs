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
                HotelFeature.WiFi, HotelFeature.Kitchen, HotelFeature.BackYard,
                HotelFeature.Refrigerator, HotelFeature.Restaurant, HotelFeature.Gym,
                HotelFeature.SwimmingPool, HotelFeature.Parking, HotelFeature.MostPicked, HotelFeature.Spa
            },
            City = City.Lagos,
            Price = 300,
            ImageUrl = "/images/HotelsBY/hotel4.jpeg"
        },
        new Hotel
        {
            Name = "Oregano",
            Features = new List<HotelFeature> { HotelFeature.WiFi, HotelFeature.Spa, HotelFeature.MostPicked, HotelFeature.Kitchen },
            City = City.Calabar,
            Price = 200,
            ImageUrl = "/images/HotelsBY/hotel4.jpeg"
        },
        new Hotel
        {
            Name = "Safe Haven",
            Features = new List<HotelFeature> { HotelFeature.WiFi, HotelFeature.Spa, HotelFeature.Gym, HotelFeature.Restaurant },
            City = City.Abuja,
            Price = 500,
            ImageUrl = "/images/HotelsBY/hotel4.jpeg"
        },
        new Hotel
        {
            Name = "Vinna Vill",
            Features = new List<HotelFeature> { HotelFeature.Bathroom, HotelFeature.WiFi, HotelFeature.Kitchen },
            City = City.Abuja,
            Price = 400,
            ImageUrl = "/images/HotelsBY/hotel4.jpeg"
        }
    };
    }
}