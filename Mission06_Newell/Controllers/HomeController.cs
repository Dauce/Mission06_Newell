using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Newell.Models;

namespace Mission06_Newell.Controllers;

public class HomeController : Controller
{
    private MovieApplicationContext _context;
    public HomeController(MovieApplicationContext temp) //Constructor
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View("GetToKnowJoel");
    }
    
    [HttpGet]
    public IActionResult AddMovies()
    {
        return View("AddMovies");
    }

    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        _context.Movies.Add(response); // Add record to database
        _context.SaveChanges();
        
        return View("Confirmation");
    }
}