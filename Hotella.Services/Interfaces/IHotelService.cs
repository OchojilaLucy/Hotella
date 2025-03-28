using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotella.Entities.Dtos;
using Hotella.Entities.Entities;

namespace Hotella.Services.Interfaces
{
    public interface IHotelService
    {
        void Create(HotelCreationDto hotelCreationDto);

        List<Hotel> GetHotels();

        void DeleteHotel(string id);


        void UpdateHotel(HotelUpdateDto hotelUpdateDto);


    }
}
