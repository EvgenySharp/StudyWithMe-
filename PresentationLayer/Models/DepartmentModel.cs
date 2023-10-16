using BusinessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class DepartmentModel
    {
        public string Name { get; init; }
        public FacultyModel Faculty { get; init; }

        public DepartmentModel(DepartmentHAP departmentHAP, FacultyModel faculty)
        {
            Name = departmentHAP.Name;
            Faculty = faculty;
        }

        public DepartmentModel() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
