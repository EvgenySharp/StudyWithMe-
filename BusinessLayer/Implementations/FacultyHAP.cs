using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class FacultyHAP
    {
        public string? Name { get; init; }

        public FacultyHAP(IEnumerable<string> navigationElements)
        {
            int indxFacName = 2;
            Name = navigationElements.ElementAtOrDefault(indxFacName);
        }

        public FacultyHAP() { }
    }
}
