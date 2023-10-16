using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IFacultyCRUD : IBaseCRUD<Faculty>
	{
		IEnumerable<Faculty> GetAllIncludeDepartments(bool includeDepartments = false);
		Faculty GetByName(string facultyName, bool includeDepartments = false);
	}
}
