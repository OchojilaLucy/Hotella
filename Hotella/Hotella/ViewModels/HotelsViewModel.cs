using Hotella.Entities.Entities;

namespace Hotella.ViewModels
{
    public class HotelsViewModel
    {
        public List<Hotel> Hotels { get; set; } = new();

        public List<Hotel> MostPickedHotels { get; set; } = new();

        public List<Hotel> HotelsWithBackyard { get; set; } = new();
        public List<Hotel> HotelsWithSwimmingPool { get; set; } = new();
        public List<Hotel> HotelsWithKitchen { get; set; } = new();

    }
}
