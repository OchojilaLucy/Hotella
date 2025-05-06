using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotella.Entities.Entities;

namespace Hotella.Entities.Dtos
{
    public class HotelUpdateDto
    {
        
        public string Name { get; set; }
        public List<string> Features { get; set; } = new List<string>();
        public City City { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
