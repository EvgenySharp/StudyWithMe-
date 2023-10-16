using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
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
