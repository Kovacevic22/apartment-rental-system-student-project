# Apartment Rental Monitoring System - Student Project

## Overview
This project is a C# desktop client–server application for monitoring and managing the apartment rental process.  
The application allows landlords to manage tenants, contracts, and rental periods.

## Technologies Used
- C# (.NET, WinForms)
- Socket programming (client–server architecture)
- JSON serialization
- Microsoft SQL Server

## System Features
- Landlord login
- Create, search, edit, and delete tenants
- Create and manage rental contracts
- Manage rental periods
- Search contracts and tenants based on various criteria
- Automatic calculation of contract amounts
- Real-time communication between client and server applications

## Running the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/Kovacevic22/apartment-rental-system-student-project.git
    ```
   
## How to Run the SQL Script

1. Open **Microsoft SQL Server Management Studio**.
2. Connect to your local SQL Server instance.
3. Open the file `Database/script.sql`.
4. Click **Execute** or press **F5** to run the script.
5. After successful execution, the `IznajmljivanjeStanova` database will be created with all required tables and relationships.
6. Once the database is created, the application can be started and will use this database.
