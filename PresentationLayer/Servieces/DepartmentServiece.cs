﻿using BusinessLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;

namespace PresentationLayer.Servieces
{
    public class DepartmentServiece
    {
        private DataManager _dataManager;
        public DepartmentServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void LoadDepartmentModelToDb(DepartmentModel departmentModel)
        {
            var departmentDb = _dataManager.Departments.GetByNameOrNullIfNotFound(departmentModel.Name);
            var IsInDataBase = departmentDb != null;
            if (!IsInDataBase)
                SaveDepartmentModelToDb(departmentModel);
        }

        private void SaveDepartmentModelToDb(DepartmentModel departmentModel)
        {
            var departmentDb = new Department();
            departmentDb.DepartmentName = departmentModel.Name;
            _dataManager.Departments.Create(departmentDb);
        }
    }
}
