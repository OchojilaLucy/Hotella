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
        public List<HotelFeature> Features { get; set; } = new List<HotelFeature>();
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 12);
        public City City { get; set; }
        public string rating { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }


        public Hotel(string name, List<HotelFeature> feat, City city, string imageUrl)
        {
            Name = name;
            Features = feat;
            City = city;
            ImageUrl = imageUrl;
        }
        public Hotel() { }
    }
}
