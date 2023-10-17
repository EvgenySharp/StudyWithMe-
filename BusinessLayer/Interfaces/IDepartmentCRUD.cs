using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
	public interface IDepartmentCRUD : IBaseCRUD<Department>
	{
		IEnumerable<Department> GetAllIncludeSubjects(bool includeSubjects = false);
		Department GetByName(string departmentName, bool includeSubjects = false);
	}
}
