using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Repository;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        //private volatile int _count;
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }
        #region FindAll
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        #endregion
        #region FindById
        public Person FindById(long id)
        {
            return _repository.FindById(id); // pesquisar SingleOrDefault(p => p.Id.Equals(id))
        }
        #endregion
        #region Create
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        #endregion
        #region Update
        public Person Update(Person person)
        {
            return _repository.Update(person);
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
