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
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/13c14622-a720-4588-9e90-f8028a75c2d4" />


Form2.cs → Authentication control
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/e05b37a6-71b5-4acf-9262-b819b4af0654" />


Form3.cs → Main menu
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/ed1412e3-6453-4db5-9ab1-120764df51f0" />


Form4.cs → Sales management
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/15108acc-db09-47c3-93c8-4e38a8f7a12c" />


Form5.cs → Product management
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/94f8a826-3d7e-437f-ba0f-0a320b0072b7" />


Form7.cs → Product listing
<img width="945" height="502" alt="image" src="https://github.com/user-attachments/assets/a8a07251-7f7e-4d6a-8604-74585977e469" />


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
