using BusinessLayer.Implementations;

namespace PresentationLayer.Models
{
    public class SubjectModel
    {
        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string ThirdName { get; init; }
        public string ActualName { get; set; }
        public DepartmentModel Department { get; init; }
        public SubjectModel(SubjectHAP subjectHAP, DepartmentModel department)
        {
            Department = department;
            FirstName = subjectHAP.FirstName;
            SecondName = subjectHAP.SecondName;
            ThirdName = subjectHAP.ThirdName;
            ActualName = subjectHAP.SecondName;
        }

        public SubjectModel() { }

        public override string ToString()
        {
            string str = FirstName;
            if (FirstName == null) { str = SecondName; }
            return str;
        }
    }
}
