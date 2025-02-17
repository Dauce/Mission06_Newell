using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission06_Newell.Models;

public class Movie
{
    public int MovieId { get; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string LentTo { get; set; }
    public string Notes { get; set; }
}