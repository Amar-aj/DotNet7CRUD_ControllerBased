using System.ComponentModel.DataAnnotations;

namespace WebApplicationCRUDTestControllerBased.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Gender { get; set; }
    public string? Address { get; set; }
    [MaxLength(10)]
    public string? MobileNo { get; set; }
}
