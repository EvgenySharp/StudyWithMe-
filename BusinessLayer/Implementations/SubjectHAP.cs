using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class SubjectHAP
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DepartmentHAP Department { get; set; }
        public SubjectHAP(IEnumerable<string> navigationElements, DepartmentHAP department, string secondName)
        {
            int indxSubName = 7;
            Department = department;
            FirstName = navigationElements.ElementAtOrDefault(indxSubName);
            SecondName = secondName;
            ThirdName = $"{FirstName} ({SecondName})";
        }
    }
}
