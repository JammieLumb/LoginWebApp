using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class DashboardController : Controller
{
    private readonly ScanInService _scanInService;

    public DashboardController()
    {
        _scanInService = new ScanInService();
    }

    public IActionResult StudentDashboard(int id)
    {
        ViewBag.PersonalSupervisorId = id;

        // Mock data for lectures and labs
        var lectures = GetLectures();
        var labs = GetLabs();

        ViewBag.Lectures = lectures;
        ViewBag.Labs = labs;

        // Get logged in student ID (replace with actual authentication logic)
        int studentId = 1; // Example student ID (replace with authenticated student ID)
        ViewBag.StudentId = studentId;

        ViewBag.ScannedLectures = _scanInService.GetScannedInSessions(studentId);

        return View("StudentDashboard");
    }

    [HttpPost]
    public IActionResult ScanIn(int studentId, int sessionId)
    {
        _scanInService.ScanIn(studentId, sessionId);
        return RedirectToAction("StudentDashboard", new { id = studentId });
    }

    private List<Lecture> GetLectures()
    {
        return new List<Lecture>
        {
            new Lecture { Id = 1, Title = "Introduction to ASP.NET", Description = "Learn the basics of ASP.NET", ChatRoomId = "lecture1_chat" },
            new Lecture { Id = 2, Title = "Entity Framework Core", Description = "Understanding EF Core for database operations", ChatRoomId = "lecture2_chat" },
            new Lecture { Id = 3, Title = "RESTful API Development", Description = "Building APIs using ASP.NET Core", ChatRoomId = "lecture3_chat" },
            new Lecture { Id = 4, Title = "JavaScript Fundamentals", Description = "Essential concepts of JavaScript programming", ChatRoomId = "lecture4_chat" },
            new Lecture { Id = 5, Title = "Responsive Web Design", Description = "Designing websites that work on all devices", ChatRoomId = "lecture5_chat" }
        };
    }

    private List<Lab> GetLabs()
    {
        return new List<Lab>
        {
            new Lab { Id = 1, Title = "Lab 1: HTML Basics", Description = "Hands-on practice with HTML", ChatRoomId = "lab1_chat" },
            new Lab { Id = 2, Title = "Lab 2: CSS Styling", Description = "Applying CSS styles to web pages", ChatRoomId = "lab2_chat" },
            new Lab { Id = 3, Title = "Lab 3: JavaScript Exercises", Description = "Coding exercises with JavaScript", ChatRoomId = "lab3_chat" },
            new Lab { Id = 4, Title = "Lab 4: ASP.NET Core Applications", Description = "Building ASP.NET Core projects", ChatRoomId = "lab4_chat" },
            new Lab { Id = 5, Title = "Lab 5: Database Queries with EF Core", Description = "Practical database queries using EF Core", ChatRoomId = "lab5_chat" }
        };
    }
}
