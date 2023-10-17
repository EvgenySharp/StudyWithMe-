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
            return View(new TestFile());
        }

        [HttpPost]
        public IActionResult Load(TestFile fileModel)
        {
            var fileAsHtml = _servicesmanager.FileServiece.GetFileAsHTML(fileModel);
            var testHAP = _servicesmanager.TestService.GetTestHAP(fileAsHtml);
            _testmodel = _servicesmanager.TestService.GetTestModel(testHAP);
            if (_testmodel.ContainsNavigationElements)
            {
                //TO DO download the test
                _servicesmanager.TestService.FacultyServiece.LoadFacultyModelToDb(_testmodel.FacultyModel);
                _servicesmanager.TestService.DepartmentServiece.LoadDepartmentModelToDb(_testmodel.DepartmentModel);
                _servicesmanager.TestService.SubjectServiece.LoadSubjectModelToDb(_testmodel.SubjectModel);
                _servicesmanager.TestService.QuestionServiece.LoadQuestionListModelToDb(_testmodel.QuestionsModel);
                _servicesmanager.TestService.AnsverServiece.LoadAnswerListModelToDb(_testmodel.AnswersModel);
            }
            fileModel.TestModel = _testmodel;


            return RedirectToAction("Index");
        }
    }
}
