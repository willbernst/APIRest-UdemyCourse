using Microsoft.EntityFrameworkCore;
using RESTAPIUdemyCourse.Model.Base;
using RESTAPIUdemyCourse.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTAPIUdemyCourse.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected MySQLContext _mySqlContext;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _mySqlContext = context;
            dataset = _mySqlContext.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _mySqlContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _mySqlContext.Entry(result).CurrentValues.SetValues(item);
                    _mySqlContext.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

    }
}
