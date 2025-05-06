using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Hotella.Services.Interfaces;
using Hotella.Entities.Entities;
using Hotella.Entities.Dtos;
using Hotella.DataBase;
using Microsoft.Data.SqlClient;


namespace Hotella.Services.Services
{
    public class BookingService : IBookingService
    {

        private readonly ILogger<BookingService> _logger;
        public static int id = 2;
        private readonly DbHelper _dbHelper;

        public BookingService(ILogger<BookingService> logger, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
        }
       
        public void CreateBooking(BookingCreationDto bookingCreationDto)
        {
            try
            {
                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    var command = new SqlCommand("INSERT INTO Bookings (HotelId, TravelerId, CheckInDate, CheckOutDate, PricePerNight) VALUES (@HotelId, @TravelerId, @CheckInDate, @CheckOutDate, @PricePerNight)", conn);
                    command.Parameters.AddWithValue("@HotelId", bookingCreationDto.HotelId);
                    command.Parameters.AddWithValue("@TravelerId", bookingCreationDto.TravelerId);
                    command.Parameters.AddWithValue("@CheckInDate", bookingCreationDto.CheckInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", bookingCreationDto.CheckOutDate);
                    command.Parameters.AddWithValue("@PricePerNight", bookingCreationDto.PricePerNight);
                    command.ExecuteNonQuery();
                }
                _logger.LogInformation("Hotel created successfully.");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error creating hotel: {ex.Message}");
            }
        }

        public void UpdateBooking(BookingUpdateDto dto)
        { 
            try
            {
                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    var command = new SqlCommand("UPDATE Bookings SET HotelId = @HotelId, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, PricePerNight = @PricePerNight WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Id", dto.Id);
                    command.Parameters.AddWithValue("@TravelerId", dto.TravelerId);
                    command.Parameters.AddWithValue("@HotelId", dto.HotelId);
                    command.Parameters.AddWithValue("@CheckInDate", dto.CheckInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", dto.CheckOutDate);
                    command.Parameters.AddWithValue("@PricePerNight", dto.PricePerNight);
                   
                    int rowsAffected = command.ExecuteNonQuery();
                    _logger.LogInformation($"{rowsAffected} booking(s) updated.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating booking: {ex.Message}");
            }
        }
        public List<Booking> GetBookingsByTravelerId(int travelerId)
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT * FROM Bookings WHERE TravelerId = @TravelerId", conn);
                    command.Parameters.AddWithValue("@TravelerId", travelerId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                HotelId = Convert.ToInt32(reader["HotelId"]),

                                TravelerId = Convert.ToInt32(reader["TravelerId"]),
                                CheckInDate = Convert.ToDateTime(reader["CheckInDate"]),
                                CheckOutDate = Convert.ToDateTime(reader["CheckOutDate"]),
                                PricePerNight = Convert.ToInt32(reader["PricePerNight"])
                            });
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving bookings: {ex.Message}");
            }
            return bookings;

        }
        public Booking GetBookingById(int bookingId)
        {
            Booking booking = null;
            try
            {
                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT * FROM Bookings WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Id", bookingId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new Booking
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                HotelId = Convert.ToInt32(reader["HotelId"]),

                                TravelerId = Convert.ToInt32(reader["TravelerId"]),
                                CheckInDate = Convert.ToDateTime(reader["CheckInDate"]),
                                CheckOutDate = Convert.ToDateTime(reader["CheckOutDate"]),
                                PricePerNight = Convert.ToInt32(reader["PricePerNight"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving booking: {ex.Message}");
            }
            return booking;

        }
        public void DeleteBooking(int bookingId)
        { 
            try
            {
                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    var command = new SqlCommand("DELETE FROM Bookings WHERE Id = @Id", conn);
                    command.Parameters.AddWithValue("@Id", bookingId);
                    int rowsAffected = command.ExecuteNonQuery();
                    _logger.LogInformation($"{rowsAffected} booking(s) deleted.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting booking: {ex.Message}");
            }
        }
        
        public decimal CalculateTotalPrice(decimal pricePerNight, int numberOfNights)
        { 
            return pricePerNight * numberOfNights;

        }
       public  DateTime CalculateCheckOutDate(DateTime checkInDate, int numberOfNights)
       {
            return checkInDate.AddDays(numberOfNights);
        }
        private void mapDtoToEntity(BookingUpdateDto dto, Booking booking)
        {
            if (!string.IsNullOrEmpty(dto.Id.ToString())) booking.Id = dto.Id;
            if (!string.IsNullOrEmpty(dto.TravelerId.ToString())) booking.TravelerId = dto.TravelerId;
            if (!string.IsNullOrEmpty(dto.HotelId.ToString())) booking.HotelId = dto.HotelId;
            if (!string.IsNullOrEmpty(dto.CheckInDate.ToString())) booking.CheckInDate = dto.CheckInDate;
            if (!string.IsNullOrEmpty(dto.CheckOutDate.ToString())) booking.CheckOutDate = dto.CheckOutDate;
            if (!string.IsNullOrEmpty(dto.PricePerNight.ToString())) booking.PricePerNight = dto.PricePerNight;
        }
    }
}
