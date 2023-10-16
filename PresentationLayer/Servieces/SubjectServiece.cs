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
    public class SubjectServiece
    {
        private DataManager _dataManager;
        public SubjectServiece(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void LoadSubjectModelToDb(SubjectModel subjectModel)
        {
            var questionDb = _dataManager.Subjects.GetByName(subjectModel.ActualName);
            bool IsInDataBase = questionDb != null;
            if (IsInDataBase!)
                SaveSubjectModelToDb(subjectModel);
        }

        private void SaveSubjectModelToDb(SubjectModel subjectModel)
        {
            var subjectDb = new Subject();
            subjectDb.SubjectName = subjectModel.ActualName;
            _dataManager.Subjects.Create(subjectDb);
        }
    }
}
