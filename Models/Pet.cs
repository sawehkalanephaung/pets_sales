using System;
using System.ComponentModel.DataAnnotations;

namespace sales_pets.Models;

public class Pet
{
 public int Id { get; set; }
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
        public string Status { get; set; } = string.Empty;

    public required List<string> PhotoUrls { get; set; }
    public required List<string> Tags { get; set; }
}
