using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataLayer.Entityes;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class TestModel
    {
        public FacultyModel FacultyModel { get; set; }
        public DepartmentModel DepartmentModel { get; set; }
        public SubjectModel SubjectModel { get; set; }
        public ICollection<QuestionModel> QuestionsModel { get; init; } = new List<QuestionModel>();
        public ICollection<AnswerModel> AnswersModel { get; init; } = new List<AnswerModel>();
        public bool ContainsNavigationElements { get; init; }

        public TestModel(TestHAP testHAP) 
        {
            FacultyModel = new FacultyModel(testHAP.Faculty);
            DepartmentModel = new DepartmentModel(testHAP.Department, FacultyModel);
            SubjectModel = new SubjectModel(testHAP.Subject, DepartmentModel);
            QuestionsModel = testHAP.Questions.Select(qHAP => new QuestionModel(qHAP)).ToList();
            AnswersModel = QuestionsModel.SelectMany(qModel => qModel.Answers).ToList();
        }

        public TestModel() { }
    }
}
