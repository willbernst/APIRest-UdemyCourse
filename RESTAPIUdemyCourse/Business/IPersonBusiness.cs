using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Hypermedia.Utils;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);

        //this method has been replaced by FindWithPagedSearch
        // List<PersonVO> FindAll();

        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);
        PersonVO Update (PersonVO person);
        PersonVO Disable(long id);
        void Delete (long id);
    }
}
