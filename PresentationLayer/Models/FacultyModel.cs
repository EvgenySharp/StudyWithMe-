using BusinessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class FacultyModel
    {
        public string Name { get; init; }

        public FacultyModel(FacultyHAP facultyHAP)
        {
            Name = facultyHAP.Name;
        }

        public FacultyModel() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
