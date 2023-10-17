using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
	public interface ISubjectCRUD  :IBaseCRUD<Subject>
	{
		IEnumerable<Subject> GetAllIncludeQuestions(bool includeQuestions = false);
		Subject GetByNameOrNullIfNotFound(string subjectName, bool includeQuestions = false);
	}
}
