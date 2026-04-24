# ELearn Pro — Real-Time E-Learning Interaction System

A full-stack web application built with **ASP.NET Core MVC (.NET 8)**, **Entity Framework Core**, **SignalR**, and **SQL Server**.

## 🚀 Features
- **Role-Based Authentication** — Admin, Instructor, Student (Cookie Auth + BCrypt)
- **Course Management** — Full CRUD for instructors/admins
- **Real-Time Live Chat** — SignalR hub with persistent message history
- **Student Enrollment** — Enroll in courses and track progress
- **Feedback System** — Star ratings and comments per course
- **Progress Tracking** — Per-student completion percentage
- **Admin Reporting** — User management, course stats, feedback summaries

## 🛠️ Tech Stack
| Layer | Technology |
|---|---|
| Backend | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core 8 |
| Database | SQL Server (LocalDB) |
| Real-time | SignalR |
| Frontend | Razor Views + Bootstrap 5 |
| Auth | Cookie Authentication + BCrypt |

## 📁 Project Structure
```
ElearningSystem/
├── Controllers/       # AccountController, CourseController, FeedbackController...
├── Data/              # ApplicationDbContext
├── Hubs/              # ChatHub (SignalR)
├── Models/            # User, Course, Enrollment, Message, Feedback, Progress
├── Services/          # UserService, CourseService, FeedbackService, ProgressService
├── Views/             # Razor Views for all pages
└── wwwroot/           # Static assets (CSS)
```

## ⚙️ Setup Instructions
1. Clone this repository
2. Ensure SQL Server LocalDB is installed (comes with Visual Studio)
3. Update `appsettings.json` connection string if needed
4. Run migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
5. Run the project:
   ```bash
   dotnet run
   ```
6. Open `https://localhost:PORT` in your browser

## 🔑 Default Admin Login
- **Email:** `admin@elearning.com`  
- **Password:** `Admin@123`

## 👥 Team Collaboration
Each team member should:
- Work on a separate feature branch
- Submit Pull Requests for review
- Write meaningful commit messages (see contribution guidelines)
