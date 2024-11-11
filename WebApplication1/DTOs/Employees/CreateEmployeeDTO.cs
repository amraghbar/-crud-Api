namespace WebApplication1.DTOs.Employees
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DepartmentId { get; set; }
    }
}
