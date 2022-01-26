using RESTAPIUdemyCourse.Data.Converter.Implementation;
using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Hypermedia.Utils;
using RESTAPIUdemyCourse.Model;
using RESTAPIUdemyCourse.Repository;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository  _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IPersonRepository repository) 
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        //public List<PersonVO> FindAll()
        //{
        //    return _converter.Parse(_repository.FindAll());
        //}

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //this method replaces FindAll
        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 1 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from Person where 1=1";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and Person.first_name like '%{name}%' ";
            query += $" order by Person.first_name {sort} limit {size} offset {offset} ";

            string countQuery = @"select count(*) from Person where 1=1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and Person.first_name like '%{name}%' ";

            var people = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> { 
                CurrentPage = page,
                List = _converter.Parse(people),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults,
            };
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
