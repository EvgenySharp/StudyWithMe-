﻿namespace DataLayer.Entityes
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
