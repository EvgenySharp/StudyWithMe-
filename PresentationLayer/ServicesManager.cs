using BusinessLayer;
using PresentationLayer.Servieces;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private FileServiece _fileServiece;
        public FileServiece FileServiece { get {return _fileServiece; } }

        private TestService _testService;
        public TestService TestService { get { return _testService; } }
        
        private DataManager _dataManager;
        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;            
            _fileServiece = new FileServiece(_dataManager);
            _testService = new TestService(_dataManager);
        }
    }
}
