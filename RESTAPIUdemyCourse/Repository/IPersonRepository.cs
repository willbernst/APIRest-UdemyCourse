using RESTAPIUdemyCourse.Model;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
