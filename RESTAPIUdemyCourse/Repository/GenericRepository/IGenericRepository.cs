using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Model.Base;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update (T item);
        void Delete (long id);
        bool Exists(long id);
    }
}