using BusinessLayer;
using DataLayer.Entityes;
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
                var answerDb = _dataManager.Answers.GetByAText(answerModel.AnswerText);
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
            answerDb.IsRight = answerModel.IsRight;
            answerDb.Question = _dataManager.Questions.GetByQText(questionText);
            _dataManager.Answers.Create(answerDb);
        }

        public void UpdateAnswerModelToDb(AnswerModel answerModel, Answer answerDb)
        {
            if (answerModel.IsRight == true)
            {
                if (answerDb.IsRight != true)
                {
                    answerDb.IsRight = answerModel.IsRight;
                    _dataManager.Answers.Update(answerDb);
                }
            }
        }
    }
}
