using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Item
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title Is Required")]
    [StringLength(50, ErrorMessage = "Title should have less than 50 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description Is Required")]
    [StringLength(100, ErrorMessage = "Description should have less than 100 characters")]
    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;

    public string Color { get; set; } = string.Empty;
}
