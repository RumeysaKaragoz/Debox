ORDER TRACKING AUTOMATION SYSTEM

Order Tracking Automation System is a desktop-based stock and sales management application developed using C# and Windows Forms.
This project was created to manage product inventory, process sales transactions, and demonstrate database-driven application logic.

Features

User authentication (database-based login)

Product adding

Product updating

Product deleting

Product listing

Stock control during sales

Insufficient stock validation

Automatic stock update after sales

Sales record creation

SQL Server integration

Technologies Used

C#

.NET Framework

Windows Forms

SQL Server

ADO.NET

Git & GitHub

Project Structure

Siparis_takip_otomasyonu/ → Main application source files

Form1.cs → Login screen

Form2.cs → Authentication control

Form3.cs → Main menu

Form4.cs → Sales management

Form5.cs → Product management

Form7.cs → Product listing

.sln → Visual Studio solution file

.gitignore → Version control configuration

Database

Main tables:

giris → User credentials

urunler → Product information

Satislar → Sales records

Connection method:

Integrated Security=True

Security Note

Database connection is configured for local SQL Server usage.
Sensitive credentials or external configuration files are not included in the repository.

Note

This project was developed for educational and learning purposes to gain practical experience in desktop application development and database integration.
