using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Hypermedia.Utils;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business
{
    public interface ICompanyBusiness
    {
        CompanyVO Create(CompanyVO company);
        CompanyVO FindById(long id);
        List<CompanyVO> FindByName(string stockName);

        //this method has been replaced by FindWithPagedSearch
        //List<CompanyVO> FindAll();

        PagedSearchVO<CompanyVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);
        CompanyVO Update(CompanyVO company);
        void Delete(long id);
    }
}
