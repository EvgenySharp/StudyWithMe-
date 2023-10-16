using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface ISubjectCRUD  :IBaseCRUD<Subject>
	{
		IEnumerable<Subject> GetAllIncludeQuestions(bool includeQuestions = false);
		Subject GetByName(string subjectName, bool includeQuestions = false);
	}
}
