using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
