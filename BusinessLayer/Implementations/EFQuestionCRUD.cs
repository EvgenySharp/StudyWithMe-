using BusinessLayer.Interfaces;
using DataLayer.Entityes;
using DataLayer;

namespace BusinessLayer.Implementations
{
    public class EFQuestionCRUD : IQuestionCRUD
    {
        private readonly EFDBContext _dbContext;

        public EFQuestionCRUD(EFDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Create(Question question)
        {
            _dbContext.Question.Add(question);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllIncludeAnswers(bool includeAnswers = false)
        {
            throw new NotImplementedException();
        }

        public Question GetByQText(string questionText, bool includeAnswers = false)
        {
            return _dbContext.Question.FirstOrDefault(q => q.QuestionText == questionText) ?? new Question();
        }

        public void Update(Question question)
        {
            //_dbContext.Entry(question).State = EntityState.Modified;
            _dbContext.Entry(question).Property(q => q.NumberOfPoints).IsModified = true;
            _dbContext.Entry(question).Property(q => q.IsRight).IsModified = true;
            _dbContext.SaveChanges();
        }

        public void Delete(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
