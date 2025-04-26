using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Services.Implementations
{
    public interface IPersonService
    {
        // method Iterface
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
