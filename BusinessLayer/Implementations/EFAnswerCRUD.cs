using BusinessLayer.AuxiliaryClasses;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Answer GetByAText(string answerText, bool includeQuestions = false)
        {
            return _dbContext.Answer.FirstOrDefault(a => a.AnswerText == answerText) ?? new Answer();
        }

        public void Update(Answer answer)
        {
            _dbContext.Entry(answer).Property(a => a.IsRight).IsModified = true;
            _dbContext.SaveChanges();
        }

        public void Delete(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
