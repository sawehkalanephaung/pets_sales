using System;

namespace sales_pets.Models;

public class Pet
{
 public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
}
