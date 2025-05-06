-- Create the database
CREATE DATABASE HotelDb;
GO

USE HotelDb;
GO

-- Create Hotels table (City as int to match enum)
CREATE TABLE Hotels (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Features NVARCHAR(MAX),
    City INT NOT NULL, -- Enum value
    Price DECIMAL(10,2) NOT NULL,
    ImageUrl NVARCHAR(255)
);
GO

-- Insert sample hotels (City = int values from your enum)
INSERT INTO Hotels (Name, Features, City, Price, ImageUrl)
VALUES 
('Jordan Suite', 'WiFi,BackYard,Refrigerator,Restaurant,Gym,Parking,Most Picked,Spa', 0, 300.00, '/images/byd/hotel4.jpeg'),
('Oregano', 'WiFi,Spa,Most Picked,Kitchen', 2, 200.00, '/images/ktn/hotel1.jpeg'),
('Safe Haven', 'WiFi,Spa,Gym,Restaurant,Swimming Pool', 1, 500.00, '/images/sp/hotel2.jpg'),
('Vinna Vill', 'Bathroom,WiFi,Kitchen,Swimming Pool,Most Picked', 1, 400.00, '/images/sp/hotel4.jpeg');
GO
