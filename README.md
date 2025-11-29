# PersonalBlog

A fully functional **ASP.NET Core MVC** blog project with Admin panel, authentication, and article management.

---

## Features

- Admin authentication (login/logout using session)
- Dashboard to view all articles
- Add, Edit, Delete articles
- MVC architecture with clean separation of concerns
- Session-based page protection for admin pages
- Responsive UI with Bootstrap
- File-based article storage using `IArticleService` (can be replaced with database later)

---

## Project Structure

PersonalBlog/
├─ Controllers/ # AdminController, AuthController, BaseController
├─ Models/ # Articles, Login
├─ Services/ # IArticleService, FileArticleService
├─ Views/ # Views for Admin, Auth, Shared
├─ wwwroot/ # Static files: CSS, JS, images
├─ Program.cs # App startup
└─ PersonalBlog.csproj
Usage

Go to /Auth/Login to log in as admin:

Username: admin

Password: password123

After login, access admin dashboard at /Admin/Dashboard

Add, Edit, Delete articles using admin panel

Logout from any page via the Logout button
y

Admin pages are protected using session-based authentication

Any attempt to access /Admin/* without login redirects to /Auth/Login

Session timeout is 30 minutes (configurable in Program.cs)
Notes

Articles are stored in files by default using FileArticleService

Can be extended to use a database like SQL Server or SQLite

Bootstrap is used for UI responsiveness

Handles cases where Edit/Delete IDs are invalid to prevent 404 errors
https://roadmap.sh/projects/personal-blog
