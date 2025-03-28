using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotella.Services.Interfaces;
using Hotella.Entities.Dtos;
using Hotella.Entities.Entities;
using Hotella.DataBase;
using Microsoft.Extensions.Logging;

namespace Hotella.Services.Services
{
    public class HotelService : IHotelService
    {
        private readonly ILogger<HotelService> _logger;
        public static int id = 2;

        public HotelService(ILogger<HotelService> logger)
        {
            _logger = logger;
        }
        public void Create(HotelCreationDto hotelCreationDto)
        {
            try
            {
                Hotel hotel = new Hotel
                (
                    hotelCreationDto.Name,
                    hotelCreationDto.Features,
                    hotelCreationDto.City,
                    hotelCreationDto.ImageUrl
                );
                DataBase.HotelDataStore.hotels.Add(hotel);
                _logger.LogInformation("Hotel created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating hotel {} {}", ex.Message, ex);
            }
        }

        public List<Hotel> GetHotels()
        {
            if (DataBase.HotelDataStore.hotels.Count() > 0)
            {
                try
                {
                    List<Hotel> hotels = DataBase.HotelDataStore.hotels;
                    _logger.LogInformation("Books returned successfully");
                    return hotels;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error occurred while fetching hotel {} {}", ex.Message, ex);
                }

            }
            return new List<Hotel>();
        }
        public void UpdateHotel(HotelUpdateDto hotelUpdateDto)
        {
            if (DataBase.HotelDataStore.hotels.Count() > 0)
            {
                try
                {
                    Hotel hotel = DataBase.HotelDataStore.hotels.Where(b => b.Id == hotelUpdateDto.Id).FirstOrDefault();
                    _logger.LogInformation("Hotel to be updated: {}", hotel);
                    if (hotel != null)
                    {
                        mapDtoToEntity(hotelUpdateDto, hotel);
                    }
                    _logger.LogInformation("hotel with id " + hotelUpdateDto.Id + " updated successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error occured while updating hotel {} {}", ex.Message, ex);
                }
            }
        }
        public void DeleteHotel(string id)
        {
            if (DataBase.HotelDataStore.hotels.Count() > 0)
            {
                try
                {
                    Hotel hotelToBeDeleted = DataBase.HotelDataStore.hotels.Where(b => b.Id == id).FirstOrDefault();
                    _logger.LogInformation("Hotel to be deleted: {}", hotelToBeDeleted);
                    if (hotelToBeDeleted != null)
                    {
                        DataBase.HotelDataStore.hotels.Remove(hotelToBeDeleted);
                    }
                    _logger.LogInformation("Hotel with id " + id + " deleted successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error occurred while deleting hotel {} {}", ex.Message, ex);
                }

            }
        }
        private void mapDtoToEntity(HotelUpdateDto dto, Hotel hotel)
        {
            if (!string.IsNullOrEmpty(dto.Name)) hotel.Name = dto.Name;
             if (!string.IsNullOrEmpty(dto.ImageUrl)) hotel.ImageUrl = dto.ImageUrl;
            if (!string.IsNullOrEmpty(dto.Features.ToString())) hotel.Features = dto.Features;
            if (!string.IsNullOrEmpty(dto.City.ToString())) hotel.City = dto.City;
            if (!string.IsNullOrEmpty(dto.Id)) hotel.Id = dto.Id;
            if (!string.IsNullOrEmpty(dto.Price.ToString())) hotel.Price = dto.Price;
        }
    }

}
