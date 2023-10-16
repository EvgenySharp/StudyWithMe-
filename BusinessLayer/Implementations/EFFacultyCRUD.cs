using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
	public class EFFacultyCRUD : IFacultyCRUD
	{
        private readonly EFDBContext _dbContext;

        public EFFacultyCRUD(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Faculty faculty)
		{
            _dbContext.Faculty.Add(faculty);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Faculty> GetAll()
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Faculty> GetAllIncludeDepartments(bool includeDepartments = false)
		{
			throw new NotImplementedException();
		}

		public Faculty GetByName(string facultyName, bool includeDepartments = false)
		{
            return _dbContext.Faculty.FirstOrDefault(f => f.FacultyName == facultyName) ?? new Faculty();
		}

		public void Update(Faculty faculty)
		{
			throw new NotImplementedException();
        }

        public void Delete(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
