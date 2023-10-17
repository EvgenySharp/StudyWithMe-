using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
		private IFacultyCRUD _facultysRepository;
		public IFacultyCRUD Facultys { get { return _facultysRepository; } }

		private IDepartmentCRUD _departmentsRepository;
		public IDepartmentCRUD Departments { get { return _departmentsRepository; } }

		private ISubjectCRUD _subjectsRepository;
		public ISubjectCRUD Subjects { get { return _subjectsRepository; } }

		private IQuestionCRUD _questionsRepository;        
        public IQuestionCRUD Questions { get { return _questionsRepository; } }

        private IAnswerCRUD _answersRepository;
        public IAnswerCRUD Answers { get { return _answersRepository; } }

        public DataManager(IFacultyCRUD facultyRepository, IDepartmentCRUD departmentRepository, 
            ISubjectCRUD subjectRepository, IQuestionCRUD questionsRepository, IAnswerCRUD answersRepository)
        {
			_facultysRepository = facultyRepository;
			_departmentsRepository = departmentRepository;
			_subjectsRepository = subjectRepository;
			_questionsRepository = questionsRepository;
            _answersRepository = answersRepository;
        }
    }
}
