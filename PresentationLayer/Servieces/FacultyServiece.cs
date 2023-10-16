using BusinessLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces
{
    public class FacultyServiece
    {
        private DataManager _dataManager;

        public FacultyServiece (DataManager dataManager) 
        {
            _dataManager = dataManager;
        }

        public void LoadFacultyModelToDb(FacultyModel facultyModel)
        {
            var facultyDb = _dataManager.Facultys.GetByName(facultyModel.Name);
            var IsInDataBase = facultyDb != null;
            if (!IsInDataBase)
                SaveFacultyModelToDb(facultyModel);
        }

        private void SaveFacultyModelToDb(FacultyModel facultyModel)
        {
            var facultyDb = new Faculty();
            facultyDb.FacultyName = facultyModel.Name;
            _dataManager.Facultys.Create(facultyDb);
        }
    }
}
