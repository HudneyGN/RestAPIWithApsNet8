using RestAPIWithApsNet8.Data.Converter.Implementations;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Repository;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        //private volatile int _count;
        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
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
        #region FindById
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id)); // pesquisar SingleOrDefault(p => p.Id.Equals(id))
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
        #endregion
        #region Delete
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        #endregion
    }
}
