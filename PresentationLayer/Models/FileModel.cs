using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;

namespace PresentationLayer.Models
{
    public class FileModel
    {
        public IFormFile File { get; set; }
        public HtmlDocument FileAsHtml { get; set; }
    }
}
