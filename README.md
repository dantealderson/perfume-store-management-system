Perfume Store Management System

A desktop application developed in C# (.NET Windows Forms) with a MySQL database to simplify the daily operations of a perfume store. The system provides separate functionalities for administrators and cashiers, allowing efficient management of inventory, customers, suppliers, sales, and pricing.

This project was developed as part of my Computer Science studies and demonstrates my experience in desktop application development, relational database design, and CRUD operations.

Features
User Authentication
Secure login system
User account management
Role-based access (Administrator and Cashier)
Inventory Management
Add new fragrances
Update fragrance information
Delete fragrances
Search inventory
Manage available stock
Brand Management
Add brands
Edit brand information
Remove brands
Customer Management
Add customers
Edit customer details
Manage customer records
Supplier Management
Manage supplier information
Store supplier details for inventory management
Sales Management
Create customer orders
Process purchases
View order history
Track completed transactions
Pricing Management
Update fragrance prices
Maintain pricing history
Reports
Generate sales reports
View inventory information
Technologies Used
C#
.NET Framework Windows Forms
MySQL
MySQL Connector
Visual Studio 2022
SQL
Project Structure
inventorymanagmentfinal/
│
├── database/                 # SQL database scripts
├── screenshots/              # Application screenshots
├── inventorymanagmentfinal/  # Source code
├── .gitignore
├── README.md
└── inventorymanagmentfinal.sln
Database

The SQL scripts required to recreate the database are located in the database/ folder.

They include the tables for:

Accounts
Users
Customers
Suppliers
Brands
Fragrances
Pricing
Orders
Order Items
History

Import the SQL files into MySQL before running the application.

Screenshots
Login




Dashboard




Inventory




Customer Management




Cashier Interface




Reports




Additional Interface




Installation
Clone the repository.
git clone <repository-url>
Open the solution file:
inventorymanagmentfinal.sln
Import the SQL files located inside the database/ folder into MySQL.
Update the MySQL connection string in the project if necessary.
Build and run the application using Visual Studio.
Skills Demonstrated

This project demonstrates experience with:

Object-Oriented Programming (OOP)
Windows Forms Development
CRUD Operations
Relational Database Design
SQL Queries
MySQL Integration
User Authentication
Desktop Application Development
Git & GitHub
Future Improvements

Possible future enhancements include:

Barcode scanner integration
Sales analytics dashboard
PDF invoice generation
Inventory notifications for low stock
Backup and restore functionality
Advanced reporting
Improved UI/UX
Search and filtering enhancements
Author

Developed by Muamal Ali

Computer Science Graduate

GitHub: github.com/dantealderson
