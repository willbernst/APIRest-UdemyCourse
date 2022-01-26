using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Model.Context;
using RESTAPIUdemyCourse.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;

namespace RESTAPIUdemyCourse.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(MySQLContext context) : base(context)
        {
        }

        public List<Company> FindByName(string stockName)
        {
            if (!string.IsNullOrWhiteSpace(stockName))
            {
                return _mySqlContext.Companies.Where(p => p.StockName.Contains(stockName)).ToList();
            }
            return null;
        }
    }
}
