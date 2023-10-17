namespace DataLayer.Entityes
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Subject>? Courses { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
    }
}
