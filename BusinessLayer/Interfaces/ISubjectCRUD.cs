using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
	public interface ISubjectCRUD  :IBaseCRUD<Subject>
	{
		IEnumerable<Subject> GetAllIncludeQuestions(bool includeQuestions = false);
		Subject GetByName(string subjectName, bool includeQuestions = false);
	}
}
