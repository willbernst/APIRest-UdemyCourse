using RESTAPIUdemyCourse.Data.Converter.Implementation;
using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Hypermedia.Utils;
using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Repository;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business.Implementations
{
    public class CompanyBusinessImplementation : ICompanyBusiness
    {
        private readonly ICompanyRepository _repository;
        private readonly CompanyConverter _converter;
        public CompanyBusinessImplementation(ICompanyRepository repository)
        {
            _repository = repository;
            _converter = new CompanyConverter();
        }

        public List<CompanyVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CompanyVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //this method replaces FindAll
        public PagedSearchVO<CompanyVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 1 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from Company where 1=1";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and Company.stock_name like '%{name}%' ";
            query += $" order by Company.stock_name {sort} limit {size} offset {offset} ";

            string countQuery = @"select count(*) from Company where 1=1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and Company.stock_name like '%{name}%' ";

            var companies = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<CompanyVO>
            {
                CurrentPage = page,
                List = _converter.Parse(companies),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults,
            };
        }

        public List<CompanyVO> FindByName(string stockName)
        {
            return _converter.Parse(_repository.FindByName(stockName));
        }
        public CompanyVO Create(CompanyVO company)
        {
            var companyEntity = _converter.Parse(company);
            companyEntity = _repository.Create(companyEntity);
            return _converter.Parse(companyEntity);
        }

        public CompanyVO Update(CompanyVO company)
        {
            var companyEntity = _converter.Parse(company);
            companyEntity = _repository.Update(companyEntity);
            return _converter.Parse(companyEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
