using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotella.Entities.Entities
{
    public class Hotel
    {
        public string Name { get; set; }
        public List<string> Features { get; set; } = new List<string>
        {
            "WiFi", "BackYard", "Refrigerator", "Restaurant", "Gym",
            "Parking", "Most Picked", "Spa", "Conference Room", "Bedroom",
            "Living Room", "Bathroom", "Dining Room", "Unit Ready",
            "Television", "Treasure To Choose", "Kitchen"
        };
        public int Id { get; set; }
        public City City { get; set; }
        public string rating { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }


        public Hotel(string name, List<string> feat, City city, decimal price, string imageUrl)
        {
            Name = name;
            Features = feat;
            City = city;
            Price = Price;
            ImageUrl = imageUrl;

        }
        public Hotel() { }
    }
}
