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