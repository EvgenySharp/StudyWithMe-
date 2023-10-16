using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBaseCRUD<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}