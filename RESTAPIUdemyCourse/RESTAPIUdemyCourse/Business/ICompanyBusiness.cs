using RESTAPIUdemyCourse.Data.VO;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business
{
    public interface ICompanyBusiness
    {
        CompanyVO Create(CompanyVO company);
        CompanyVO FindById(long id);
        List<CompanyVO> FindAll();
        CompanyVO Update(CompanyVO company);
        void Delete(long id);
    }
}
