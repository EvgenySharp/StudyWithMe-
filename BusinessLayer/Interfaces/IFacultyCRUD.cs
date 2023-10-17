using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
	public interface IFacultyCRUD : IBaseCRUD<Faculty>
	{
		IEnumerable<Faculty> GetAllIncludeDepartments(bool includeDepartments = false);
		Faculty GetByName(string facultyName, bool includeDepartments = false);
	}
}
