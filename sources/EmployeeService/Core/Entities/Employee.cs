namespace Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }
    }
}
