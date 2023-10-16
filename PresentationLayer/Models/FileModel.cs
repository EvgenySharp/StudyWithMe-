using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class TitleTest
    {

        [Required]
        public string Name { get; set; }

        public TitleTest() { }
    }

    public class TestModelNEW
    {
        public int Id { get; set; }

        [Required]
        public TitleTest TitleTest { get; set; }

        public string Html { get; set; }

        public TestModelNEW() { }
    }
    public class FileModel
    {
        public IFormFile File { get; set; }
        public HtmlDocument FileAsHtml { get; set; }
        public TestModel TestModel { get; set; }
        public TestModelNEW TestModelNEW { get; set; }
    }
}
