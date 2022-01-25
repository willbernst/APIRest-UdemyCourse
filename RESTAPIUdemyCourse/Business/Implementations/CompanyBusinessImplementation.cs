using RESTAPIUdemyCourse.Data.Converter.Implementation;
using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Repository;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business.Implementations
{
    public class CompanyBusinessImplementation : ICompanyBusiness
    {
        private readonly IGenericRepository<Company> _repository;
        private readonly CompanyConverter _converter;
        public CompanyBusinessImplementation(IGenericRepository<Company> repository)
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
