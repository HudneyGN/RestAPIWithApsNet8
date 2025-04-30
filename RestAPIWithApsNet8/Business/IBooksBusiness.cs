using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Business
{
    public interface IBooksBusiness
    {
        // method Iterface
        Books Create(Books book);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books book);
        void Delete(long id);
    }
}
