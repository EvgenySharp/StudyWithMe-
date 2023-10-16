using BusinessLayer;
using BusinessLayer.AuxiliaryClasses;
using DataLayer.Entityes;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces
{
    public class FileServiece
    {
        private string _newFilePath;
        private DataManager _dataManager;

        public FileServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Start(FileModel fileModel)
        {            
            CreateNewHTMLFile(fileModel);
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(_newFilePath);
            fileModel.FileAsHtml = htmlDoc;
        }

        private void CreateNewHTMLFile(FileModel fileModel)
        {
            SetNewFilePath(fileModel);
            using (var stream = new FileStream(_newFilePath, FileMode.Create))
            {
                fileModel.File.CopyToAsync(stream);
            }
        }

        private void SetNewFilePath(FileModel fileModel)
        { 
            string path = @"D:\new";
            string fileName = fileModel.File.FileName;
            _newFilePath = Path.Combine(path, fileName);
        }
    }
}
