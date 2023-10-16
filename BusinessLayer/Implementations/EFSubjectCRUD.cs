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
	public class EFSubjectCRUD : ISubjectCRUD
	{
        private readonly EFDBContext _dbContext;

        public EFSubjectCRUD(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Subject subject)
        {
            _dbContext.Subject.Add(subject);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Subject> GetAll()
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Subject> GetAllIncludeQuestions(bool includeQuestions = false)
		{
			throw new NotImplementedException();
		}

		public Subject GetByName(string subjectName, bool includeQuestions = false)
        {
            return _dbContext.Subject.FirstOrDefault(s => s.SubjectName == subjectName) ?? new Subject();
        }

		public void Update(Subject subject)
		{
			throw new NotImplementedException();
        }

        public void Delete(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
