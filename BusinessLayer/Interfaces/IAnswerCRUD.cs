using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
    public interface IAnswerCRUD : IBaseCRUD<Answer>
    {
        IEnumerable<Answer> GetAllIncludeQuestions(bool includeQuestions = false);
        Answer GetByAText(string answerText, bool includeQuestions = false);
    }
}
