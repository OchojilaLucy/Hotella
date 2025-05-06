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
                Features = new List<string>
                {
                    "WiFi", "BackYard", "Refrigerator", "Restaurant", "Gym",
                    "Parking", "Most Picked", "Spa"
                },
                City = City.Lagos,
                Price = 300,
                ImageUrl = "/images/byd/hotel4.jpeg"
            },
            new Hotel
            {
                Name = "Oregano",
                Features = new List<string>
                {
                    "WiFi", "Spa", "Most Picked", "Kitchen"
                },
                City = City.Calabar,
                Price = 200,
                ImageUrl = "/images/ktn/hotel1.jpeg"
            },
            new Hotel
            {
                Name = "Safe Haven",
                Features = new List<string>
                {
                    "WiFi", "Spa", "Gym", "Restaurant", "Swimming Pool"
                },
                City = City.Abuja,
                Price = 500,
                ImageUrl = "/images/sp/hotel2.jpg"
            },
            new Hotel
            {
                Name = "Vinna Vill",
                Features = new List<string>
                {
                    "Bathroom", "WiFi", "Kitchen", "Swimming Pool", "Most Picked"
                },
                City = City.Abuja,
                Price = 400,
                ImageUrl = "/images/sp/hotel4.jpeg"
            }
        };
    }
}
