using System;
using RestAPIWithApsNet8.Data.Converter.Implementations;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Repository;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        //private volatile int _count;
        private readonly IRepository<Books> _repository;
        private readonly BooksConverter _converter;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }
        #region FindAll
        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        #endregion
        #region FindById
        public BooksVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        #endregion
        #region Create
        public BooksVO Create(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        #endregion
        #region Update
        public BooksVO Update(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
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
