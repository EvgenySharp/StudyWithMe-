namespace DataLayer.Entityes
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
