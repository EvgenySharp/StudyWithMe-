using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class DepartmentHAP
    {
        public string? Name { get; init; }
        public FacultyHAP Faculty { get; init; }

        public DepartmentHAP(IEnumerable<string> navigationElements, FacultyHAP faculty)
        {
            int indxDepName = 3;
            Name = navigationElements.ElementAtOrDefault(indxDepName);
            Faculty = faculty;
        }

        public DepartmentHAP() { }
    }
}
