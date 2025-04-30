using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Repository;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        //private volatile int _count;
        private readonly IRepository<Books> _repository;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
        }
        #region FindAll
        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }
        #endregion
        #region FindById
        public Books FindById(long id)
        {
            return _repository.FindById(id); // pesquisar SingleOrDefault(p => p.Id.Equals(id))
        }
        #endregion
        #region Create
        public Books Create(Books book)
        {
            return _repository.Create(book);
        }
        #endregion
        #region Update
        public Books Update(Books book)
        {
            return _repository.Update(book);
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
