##🛒 E-Commerce Web API 🚀
A scalable backend system built with ASP.NET Core Web API following Clean
Architecture principles.
authentication to order management.

##🌟 Features
1.🔐 Authentication & Authorization (JWT + ASP.NET Identity)
2.👥 Role-based access control (Admin / User)
3.📦 Product & Category management (CRUD)
4.🛒 Persistent Shopping Cart system
5.📑 Order management with status tracking
6.🔍 Advanced filtering using LINQ & IQueryable
7.🛡️ Rate limiting for API protection

##🏗️ Architecture & Design Patterns
1.Clean Architecture: Separation of concerns with distinct layers (Presentation, Application, Domain, Infrastructure).
2.Repository Pattern
3.DTO-based data transfer
4.Soft Delete implementation
5.Dependency Injection

##🛠️ Tech Stack
1.Framework: ASP.NET Core 8.0
2.Entity Framework Core
3.Microsoft SQL Server
4.JWT Authentication
5.Swagger / OpenAPI for API documentation

##🚀 Getting Started
## 📌 Prerequisites
Before running the project, make sure you have installed:
- .NET 8 SDK
- SQL Server (Local or Remote)
- Visual Studio 2022 or VS Code
- Postman (optional for testing APIs) 

## 📥 Clone the repo
git clone https://github.com/ya52400000-sketch/ecommarce-project.git

## 🗄️ Database Setup
1. Open `appsettings.json`
2. Update connection string:
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ecoomerance_api_db;Trusted_Connection=True;TrustServerCertificate=True"}
3. Run migrations:
    dotnet ef database update

 ## ▶️ Run the project
    dotnet run
##📍 API Documentation
After running the project, open:
https://localhost:7015/swagger/index.html

## 🔐 Default Accounts 
Admin:
Email:admin@gmail.com
Password:Admin@123

##Developed with ❤️ by [Yossef Elbarbary]