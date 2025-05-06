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
        List<Hotel> GetHotelsByFeature(string feature);
        //Hotel SelectHotel(string hotelName);

        Hotel? GetHotel(string hotelName);
        void DeleteHotel(int id);


        void UpdateHotel(HotelUpdateDto hotelUpdateDto);


    }
}
