using RESTAPIUdemyCourse.Model;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Repository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        List<Company> FindByName(string stockName);
    }
}
