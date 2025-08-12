namespace todo.Models;
using System.ComponentModel.DataAnnotations;


public class todolist
{
    [Required]
    [Display(Name="Task")]
    public string Task { get; set; }

    [Required]
    [Display(Name="Description")]
    public string Description { get; set; }

    [Required]
    [Display(Name="status")]
    public string status { get; set; }

}
