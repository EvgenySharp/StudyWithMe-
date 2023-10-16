using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAnswerCRUD : IBaseCRUD<Answer>
    {
        IEnumerable<Answer> GetAllIncludeQuestions(bool includeQuestions = false);
        Answer GetByAText(string answerText, bool includeQuestions = false);
    }
}
