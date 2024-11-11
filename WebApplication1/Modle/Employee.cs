namespace WebApplication1.Modle
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department department { get; set; } = null!;

    }
}
