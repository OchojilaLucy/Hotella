🏨 **Hotel Booking Website (ASP.NET MVC)**
This is a simple hotel booking web application built with ASP.NET MVC and ADO.NET for database operations.

## 🚀 Setup Instructions

1. Clone the repository: https://github.com/OchojilaLucy/Hotella
   
2. Set up your database: Run the SQL script in /Hotella.DataBase/setup.sql using SQL Server Management Studio (SSMS).

3. Configure your connection string: Copy the example config file:

   |bash                                           |
   |copy appsettings.example.json appsettings.json |
    Open appsettings.json and replace the placeholder values with your actual SQL Server credentials.

4. Run the project: Open the solution in Visual Studio.
   Press F5 to build and run the application.


## 🔒 Security

**Important:** Your actual `appsettings.json` is excluded from Git. Never commit real credentials.

📦 **Features**
-Hotel listing and room booking
-Customer registration and login
-Admin panel for managing hotels and bookings
-SQL Server database integration (ADO.NET)

⚙️ **Technologies Used**
-ASP.NET MVC (C#)
-ADO.NET (SQL Connection, Command, DataReader)
-SQL Server
-Bootstrap for UI
-Razor Views

