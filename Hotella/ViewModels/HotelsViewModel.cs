using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Hotella.Entities.Entities;

namespace Hotella.ViewModels
{
    public class HotelsViewModel
    {
        //private readonly Hotel hotel;
        public HotelsViewModel(Hotel hotel)
        {
            Name = hotel.Name;
            ImageUrl = hotel.ImageUrl;
            City = hotel.City.ToString();
            Price = hotel.Price;
            Features = hotel.Features;
        }
        public HotelsViewModel()
        {
        }
        public int NumberOfNights { get; set; } = 1;
        public decimal TotalPrice => (hotel?.Price ?? 0) * NumberOfNights;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate => CheckInDate.AddDays(NumberOfNights);


        public List<Hotel> Hotels { get; set; } = new();

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }  // Ensure Price exists in Hotel class
        public List<string> Features { get; set; } = new();
       
        public List<Hotel> MostPickedHotels { get; set; } = new();

        public List<Hotel> HotelsWithBackyard { get; set; } = new();
        public List<Hotel> HotelsWithSwimmingPool { get; set; } = new();
        public List<Hotel> HotelsWithKitchen { get; set; } = new();
        public Hotel hotel { get; set; } = new();   
    }
}
