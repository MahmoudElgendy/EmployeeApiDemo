using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Range(0, 1000000)]
        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
    }
}
