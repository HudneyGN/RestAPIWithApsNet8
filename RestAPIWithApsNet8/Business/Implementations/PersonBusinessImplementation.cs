using System.Globalization;
using RestAPIWithApsNet8.Data.Converter.Implementations;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Hypermedia.Utils;
using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Repository;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        //private volatile int _count;
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        #region FindAll
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        #endregion
        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1 = 1" ;
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and p.first_name like '%{name}%'";
            query+= $" order by p.first_name {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and p.name like '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> {
                CurrentPage = page,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        #region FindById
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id)); // pesquisar SingleOrDefault(p => p.Id.Equals(id))
        }
        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }
        #endregion
        #region Create
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        #endregion
        #region Update
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
        #endregion
        #region Delete
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        #endregion
    }
}
