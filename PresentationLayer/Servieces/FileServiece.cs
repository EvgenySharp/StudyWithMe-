using BusinessLayer;
using HtmlAgilityPack;
using PresentationLayer.Models;

namespace PresentationLayer.Servieces
{
    public class FileServiece
    {
        private DataManager _dataManager;

        public FileServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public HtmlDocument GetFileAsHTML(TestFile fileModel)
        {
            var htmlDoc = new HtmlDocument();
            var s = fileModel.File.OpenReadStream();
            htmlDoc.Load(s);
            CheckingThatFileTest(htmlDoc);
            return htmlDoc;
        }

        private void CheckingThatFileTest(HtmlDocument htmlDoc)
        {
            var navigationNodes = htmlDoc.DocumentNode
                   .SelectNodes("//html/" +
                                   "/body/" +
                                       "/div" +
                                           "/div" +
                                               "/header" +
                                                   "/div" +
                                                       "/div" +
                                                           "/div" +
                                                               "/div" +
                                                                   "/div" +
                                                                       "/nav" +
                                                                           "/ol");
            if (navigationNodes == null)
            {
                throw new InvalidOperationException("Most likely the downloaded file is not a test");
            }
        }


    }
}
