using RESTAPIUdemyCourse.Data.Converter.Contract;
using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Model;
using System.Collections.Generic;
using System.Linq;

namespace RESTAPIUdemyCourse.Data.Converter.Implementation
{
    public class CompanyConverter : IParser<CompanyVO, Company>, IParser<Company, CompanyVO>
    {
        public Company Parse(CompanyVO origin)
        {
            if (origin == null) return null;
            return new Company
            {
                Id = origin.Id,
                StockName = origin.StockName,
                StockSector = origin.StockSector,
                Ein = origin.Ein,
                Address = origin.Address,
            };
        }

        public List<Company> Parse(List<CompanyVO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }

        public CompanyVO Parse(Company origin)
        {
            if (origin == null) return null;
            return new CompanyVO
            {
                Id = origin.Id,
                StockName = origin.StockName,
                StockSector = origin.StockSector,
                Ein = origin.Ein,
                Address = origin.Address,
            };
        }

        public List<CompanyVO> Parse(List<Company> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
