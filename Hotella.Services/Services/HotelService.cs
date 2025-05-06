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
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotella.Services.Services
{
    public class HotelService : IHotelService
    {
        private readonly ILogger<HotelService> _logger;
        private readonly DbHelper _dbHelper;

        public HotelService(ILogger<HotelService> logger, DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
        }
        public void Create(HotelCreationDto hotelCreationDto)
        {
            SqlConnection conn = null;

            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var command = new SqlCommand("INSERT INTO Hotels (Id, Name, Features, City, Price, ImageUrl) VALUES (@Id, @Name, @Features, @City, @Price, @ImageUrl)", conn);
                command.Parameters.AddWithValue("@Id", hotelCreationDto.Id);
                command.Parameters.AddWithValue("@Name", hotelCreationDto.Name);
                command.Parameters.AddWithValue("@Features", string.Join(",", hotelCreationDto.Features));
                command.Parameters.AddWithValue("@City", (int)hotelCreationDto.City);
                command.Parameters.AddWithValue("@Price", hotelCreationDto.Price);
                command.Parameters.AddWithValue("@ImageUrl", hotelCreationDto.ImageUrl);

                command.ExecuteNonQuery();
                _logger.LogInformation("Hotel created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating hotel: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    _logger.LogInformation("Connection closed.");
                }
            }
        }


        public List<Hotel> GetHotelsByFeature(string feature)
        {
            var hotels = new List<Hotel>();

            SqlConnection conn = null;

            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var command = new SqlCommand("SELECT * FROM Hotels WHERE Features LIKE @Feature", conn);
                command.Parameters.AddWithValue("@Feature", $"%{feature}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hotels.Add(new Hotel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Features = reader["Features"].ToString().Split(',').ToList(),
                            City = (City)Convert.ToInt32(reader["City"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            ImageUrl = reader["ImageUrl"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving hotels by feature: {ex.Message}");
            }
            finally
            {
                conn?.Close(); // Make sure to close the connection explicitly
            }

            return hotels;
        }



        public Hotel? GetHotel(string hotelName)
        {
            SqlConnection conn = null;
            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var command = new SqlCommand("SELECT * FROM Hotels WHERE Name = @Name", conn);
                command.Parameters.AddWithValue("@Name", hotelName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Hotel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Features = reader["Features"].ToString().Split(',').ToList(),
                            City = (City)Convert.ToInt32(reader["City"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            ImageUrl = reader["ImageUrl"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving hotel: {ex.Message}");
            }
            finally
            {
                if (conn?.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return null;
        }


        public List<Hotel> GetHotels() 
        {
            var hotels = new List<Hotel>();
            SqlConnection conn = null;
            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var command = new SqlCommand("SELECT * FROM Hotels", conn);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hotels.Add(new Hotel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Features = reader["Features"].ToString().Split(',').ToList(),
                            City = (City)Convert.ToInt32(reader["City"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            ImageUrl = reader["ImageUrl"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving hotels: {ex.Message}");
            }
            finally
            {
                conn?.Close();
            }

            return hotels;
        }


        public void UpdateHotel(HotelUpdateDto dto)
        {
            SqlConnection conn = null;
            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var command = new SqlCommand(@"UPDATE Hotels 
            SET Name = @Name, Features = @Features, City = @City, Price = @Price, ImageUrl = @ImageUrl 
            WHERE Id = @Id", conn);

                command.Parameters.AddWithValue("@Id", dto.Id);
                command.Parameters.AddWithValue("@Name", dto.Name ?? string.Empty);
                command.Parameters.AddWithValue("@Features", string.Join(",", dto.Features));
                command.Parameters.AddWithValue("@City", (int)dto.City);
                command.Parameters.AddWithValue("@Price", dto.Price);
                command.Parameters.AddWithValue("@ImageUrl", dto.ImageUrl ?? string.Empty);

                int rowsAffected = command.ExecuteNonQuery();
                _logger.LogInformation($"{rowsAffected} hotel(s) updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating hotel: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    _logger.LogInformation("Connection closed.");
                }
            }
        }

        public void DeleteHotel(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = _dbHelper.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var command = new SqlCommand("DELETE FROM Hotels WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", id);

                int rows = command.ExecuteNonQuery();
                _logger.LogInformation($"{rows} hotel(s) deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting hotel: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    _logger.LogInformation("Connection closed.");
                }
            }
        }

        private void mapDtoToEntity(HotelUpdateDto dto, Hotel hotel)
        {
            if (!string.IsNullOrEmpty(dto.Name)) hotel.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.ImageUrl)) hotel.ImageUrl = dto.ImageUrl;
            if (dto.Features != null && dto.Features.Any()) hotel.Features = dto.Features;
            hotel.City = dto.City;
            hotel.Id = dto.Id;
            hotel.Price = dto.Price;
        }

    }

}
