using BusinessLayer;
using DataLayer.Entityes;
using DataLayer.Enums;
using PresentationLayer.Models;

namespace PresentationLayer.Servieces
{
    public class AnswerServiece
    {
        private DataManager _dataManager;
        public AnswerServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void LoadAnswerListModelToDb(ICollection<AnswerModel> answerModels)
        {
            foreach (var answerModel in answerModels)
            {
                var answerDb = _dataManager.Answers.GetByATextOrNullIfNotFound(answerModel.AnswerText);
                bool IsInDataBase = answerDb != null;
                if (IsInDataBase)
                    UpdateAnswerModelToDb(answerModel, answerDb);
                else
                    SaveAnswerModelToDb(answerModel, answerModel.Question.QuestionText);
            }
        }

        public void SaveAnswerModelToDb(AnswerModel answerModel, string questionText)
        {
            var answerDb = new Answer();
            answerDb.AnswerText = answerModel.AnswerText;
            answerDb.AnswerStatus = answerModel.AnswerStatus;
            answerDb.Question = _dataManager.Questions.GetByQTextOrNullIfNotFound(questionText);
            _dataManager.Answers.Create(answerDb);
        }

        public void UpdateAnswerModelToDb(AnswerModel answerModel, Answer answerDb)
        {
            if (answerModel.AnswerStatus == AnswerStatus.Correct)
            {
                if (answerDb.AnswerStatus != AnswerStatus.Correct)
                {
                    answerDb.AnswerStatus = answerModel.AnswerStatus;
                    _dataManager.Answers.Update(answerDb);
                }
            }
        }
    }
}
