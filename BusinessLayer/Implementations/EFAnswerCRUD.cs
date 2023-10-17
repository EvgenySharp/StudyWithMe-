using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;

namespace BusinessLayer.Implementations
{
    public class EFAnswerCRUD : IAnswerCRUD
    {
        private readonly EFDBContext _dbContext;

        public EFAnswerCRUD(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Answer answer)
        {
            _dbContext.Answer.Add(answer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Answer> GetAllIncludeQuestions(bool includeQuestions = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer? GetByATextOrNullIfNotFound(string answerText, bool includeQuestions = false)
        {
            return _dbContext.Answer.FirstOrDefault(a => a.AnswerText == answerText);
        }

        public void Update(Answer answer)
        {
            _dbContext.Entry(answer).Property(a => a.AnswerStatus).IsModified = true;
            _dbContext.SaveChanges();
        }

        public void Delete(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
