using BusinessLayer;
using PresentationLayer.Models;
using PresentationLayer.Servieces;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
