using BusinessLayer;
using BusinessLayer.Implementations;
using HtmlAgilityPack;
using PresentationLayer.Models;

namespace PresentationLayer.Servieces
{
    public class TestService
    {
        private FacultyServiece _facultyServiece;
        public FacultyServiece FacultyServiece { get { return _facultyServiece; } }

        private DepartmentServiece _departmentServiece;
        public DepartmentServiece DepartmentServiece { get { return _departmentServiece; } }

        private SubjectServiece _subjectServiece;
        public SubjectServiece SubjectServiece { get { return _subjectServiece; } }

        private QuestionServiece _questionServiece;
        public QuestionServiece QuestionServiece { get { return _questionServiece; } }

        private AnswerServiece _ansverServiece;
        public AnswerServiece AnsverServiece { get { return _ansverServiece; } }

        private DataManager _dataManager;
        public TestService(DataManager dataManager) 
        {
            _dataManager = dataManager;
            _facultyServiece = new FacultyServiece(_dataManager);
            _departmentServiece = new DepartmentServiece(_dataManager);
            _subjectServiece = new SubjectServiece(_dataManager);
            _questionServiece = new QuestionServiece(_dataManager);
            _ansverServiece = new AnswerServiece(_dataManager);
        }

        public TestModel GetTestModel(HtmlDocument htmlDoc)
        {
            var testhap = new TestHAP(htmlDoc);
            var testModel = new TestModel(testhap);
            return testModel;
        }
    }
}
