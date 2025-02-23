using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies");
    }

    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        _context.Movies.Add(response); // Add record to database
        _context.SaveChanges();
        
        return View("Confirmation");
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .ToList();
        return View(movies);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
            
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies", recordToEdit);
        
    }
    
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList"); // Go to the action, not the view
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
    
}