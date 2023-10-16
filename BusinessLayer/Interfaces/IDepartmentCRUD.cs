using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IDepartmentCRUD : IBaseCRUD<Department>
	{
		IEnumerable<Department> GetAllIncludeSubjects(bool includeSubjects = false);
		Department GetByName(string departmentName, bool includeSubjects = false);
	}
}
