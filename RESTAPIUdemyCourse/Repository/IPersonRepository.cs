using RESTAPIUdemyCourse.Model;

namespace RESTAPIUdemyCourse.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person Disable(long id);
    }
}
