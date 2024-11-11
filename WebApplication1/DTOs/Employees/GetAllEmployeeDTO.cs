namespace WebApplication1.DTOs.Employees
{
    public class GetAllEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DepartmentId { get; set; }

    }
}
