using DataLayer.Entityes;

namespace BusinessLayer.Interfaces
{
    public interface IQuestionCRUD : IBaseCRUD<Question>
    {
        IEnumerable<Question> GetAllIncludeAnswers(bool includeAnswers = false);
        Question GetByQTextOrNullIfNotFound(string questionText, bool includeAnswers = false);
    }
}
