﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotella.Entities.Entities;

namespace Hotella.Entities.Dtos
{
    public class HotelCreationDto
    {
        public string Name { get; set; }
        public List<HotelFeature> Features { get; set; } = new List<HotelFeature>();
        public City City { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
