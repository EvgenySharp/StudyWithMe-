using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;

namespace PresentationLayer.Models
{
    public class TestFile
    {
        public IFormFile File { get; set; }
        public TestModel TestModel { get; set; }
    }
}
