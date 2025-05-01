using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Business
{
    public interface IBooksBusiness
    {
        // method Iterface
        BooksVO Create(BooksVO book);
        BooksVO FindById(long id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO book);
        void Delete(long id);
    }
}
