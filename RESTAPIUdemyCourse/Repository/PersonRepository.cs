using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Model.Context;
using RESTAPIUdemyCourse.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTAPIUdemyCourse.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context)
        {

        }

        public Person Disable(long id)
        {
            if (!_mySqlContext.People.Any(p => p.Id.Equals(id))) return null;
            var user = _mySqlContext.People.SingleOrDefault(p => p.Equals(id));
            if(user != null)
            {
                user.Enabled = false;
                try
                {
                    _mySqlContext.Entry(user).CurrentValues.SetValues(user);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _mySqlContext.People.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _mySqlContext.People.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _mySqlContext.People.Where(p => p.LastName.Contains(firstName)).ToList();
            }
            return null;
        }
    }
}
