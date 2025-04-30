using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Repository
{
    public interface IPersonRepository
    {
        // method Iterface
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);
    }
}
