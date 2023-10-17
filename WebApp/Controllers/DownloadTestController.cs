using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

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
            //_servicesmanager.TestService.FacultyServiece.LoadFacultyModelToDb(_testmodel.FacultyModel);
            //_servicesmanager.TestService.DepartmentServiece.LoadDepartmentModelToDb(_testmodel.DepartmentModel);
            //_servicesmanager.TestService.SubjectServiece.LoadSubjectModelToDb(_testmodel.SubjectModel);
            //_servicesmanager.TestService.QuestionServiece.LoadQuestionListModelToDb(_testmodel.QuestionsModel);
            //_servicesmanager.TestService.AnsverServiece.LoadAnswerListModelToDb(_testmodel.AnswersModel);
            return View(fileModel);
        }
    }
}
