using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;

namespace BusinessLayer.Implementations
{
	public class EFDepartmentCRUD : IDepartmentCRUD
	{
        private readonly EFDBContext _dbContext;

        public EFDepartmentCRUD(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Department department)
        {
            _dbContext.Department.Add(department);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Department> GetAllIncludeSubjects(bool includeSubjects = false)
		{
			throw new NotImplementedException();
		}

		public Department GetByName(string departmentName, bool includeSubjects = false)
        {
            return _dbContext.Department.FirstOrDefault(d => d.DepartmentName == departmentName) ?? new Department();
        }

		public void Update(Department department)
		{
			throw new NotImplementedException();
		}

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
