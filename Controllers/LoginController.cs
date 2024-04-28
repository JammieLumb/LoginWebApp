using LoginWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LoginController : Controller
{
    private const string UsersFilePath = "users.txt";

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        // Load users from text file
        List<UserModel> users = LoadUsers();

        // Find user with matching credentials
        UserModel user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            // Redirect based on user's role
            switch (user.Role)
            {
                case "student":
                    return RedirectToAction("StudentDashboard", "Dashboard", new { id = user.RelatedId });
                case "supervisor":
                    return RedirectToAction("SupervisorDashboard", "Dashboard");
                case "lecturer":
                    return RedirectToAction("LecturerDashboard", "Dashboard");
                default:
                    return RedirectToAction("Index");
            }
        }

        ViewBag.ErrorMessage = "Invalid username or password";
        return View();
    }

    private List<UserModel> LoadUsers()
    {
        List<UserModel> users = new List<UserModel>();

        // Read users from text file
        string[] lines = System.IO.File.ReadAllLines(UsersFilePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4)
            {
                users.Add(new UserModel
                {
                    Username = parts[0],
                    Password = parts[1],
                    Role = parts[2],
                    RelatedId = Convert.ToInt32(parts[3])
                });
            }
        }

        return users;
    }
}
