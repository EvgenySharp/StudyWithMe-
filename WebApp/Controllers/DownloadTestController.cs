using BusinessLayer;
using DataLayer.Entityes;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using PresentationLayer.Servieces;
using System.ComponentModel.DataAnnotations;
using System.IO;
using static DataLayer.Enums.PageEnums;

namespace WebApp.Controllers
{


    public class DownloadTestController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        private TestModel _testmodel;
        public DownloadTestController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            return View(new FileModel());
        }

        [HttpPost]
        public IActionResult Load(FileModel fileModel)
        {
            _servicesmanager.FileServiece.Start(fileModel);
            _testmodel = _servicesmanager.TestService.GetTestModel(fileModel.FileAsHtml);
            fileModel.TestModel = _testmodel;
            //_servicesmanager.TestService.FacultyServiece.LoadFacultyModelToDb(_testmodel.FacultyModel);
            //_servicesmanager.TestService.DepartmentServiece.LoadDepartmentModelToDb(_testmodel.DepartmentModel);
            //_servicesmanager.TestService.SubjectServiece.LoadSubjectModelToDb(_testmodel.SubjectModel);
            //_servicesmanager.TestService.QuestionServiece.LoadQuestionListModelToDb(_testmodel.QuestionsModel);
            //_servicesmanager.TestService.AnsverServiece.LoadAnswerListModelToDb(_testmodel.AnswersModel);
            var testModelNEW = new TestModelNEW()
            {
                Id = 1,
                TitleTest = new TitleTest() { Name = "information"},
            };
            fileModel.TestModelNEW = testModelNEW;
            return View(fileModel);
        }

        [HttpPost]
        public IActionResult SaveTestNEWModel(TestModelNEW model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveTestModel(TestModel model)
        {
            return View();
        }

        public IActionResult Model(int fileModel)
        {
            return View(fileModel);
        }
    }
}
