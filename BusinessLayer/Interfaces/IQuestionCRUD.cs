using BusinessLayer.AuxiliaryClasses;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IQuestionCRUD : IBaseCRUD<Question>
    {
        IEnumerable<Question> GetAllIncludeAnswers(bool includeAnswers = false);
        Question GetByQText(string questionText, bool includeAnswers = false);
    }
}
