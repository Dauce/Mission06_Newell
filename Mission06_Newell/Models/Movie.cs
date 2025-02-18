using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission06_Newell.Models;

public class Movie
{
    
    [Required]
    [Key]
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
}