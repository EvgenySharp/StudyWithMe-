using BusinessLayer;
using BusinessLayer.AuxiliaryClasses;
using BusinessLayer.Implementations;
using DataLayer.Entityes;
using HtmlAgilityPack;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces
{
    public class QuestionServiece
    {
        private DataManager _dataManager;
        private AnswerServiece _ansverServiece;
        public QuestionServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
            _ansverServiece = new AnswerServiece(dataManager);
        }

        public void LoadQuestionListModelToDb(ICollection<QuestionModel> questionModels)
        {
            foreach (var questionModel in questionModels)
            {
                var questionDb = _dataManager.Questions.GetByQText(questionModel.QuestionText);
                var IsInDataBase = questionDb != null;
                if (IsInDataBase)
                    UpdateQuestionModelToDb(questionModel, questionDb);
                else
                    SaveQuestionModelToDb(questionModel);
            }
        }

        private void SaveQuestionModelToDb(QuestionModel questionModel)
        {
            var questionDb = new Question();
            questionDb.QuestionText = questionModel.QuestionText;
            questionDb.NumberOfPoints = questionModel.NumberOfPoints;
            questionDb.IsRight = questionModel.IsRight;
            questionDb.MultipleAnswerOptions = questionModel.MultipleAnswerOptions;
            _dataManager.Questions.Create(questionDb);
        }

        private void UpdateQuestionModelToDb(QuestionModel questionModel, Question questionDb)
        {
            if (questionModel.NumberOfPoints > questionDb.NumberOfPoints)
            {
                questionDb.NumberOfPoints = questionModel.NumberOfPoints;
                questionDb.IsRight = questionModel.IsRight;
                _dataManager.Questions.Update(questionDb);
            }            
        }

        public void WriteQuestionsToFile(ICollection<QuestionModel> questionModels) 
        {
            // TO DO            
        }
    }
}
