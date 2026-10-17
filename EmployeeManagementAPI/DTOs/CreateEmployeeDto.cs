using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs;

public class CreateEmployeeDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    [Range(0, 1000000)]
    public decimal Salary { get; set; }

    public DateTime HireDate { get; set; }
}