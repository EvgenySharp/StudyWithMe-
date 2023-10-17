using BusinessLayer.Implementations;

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
