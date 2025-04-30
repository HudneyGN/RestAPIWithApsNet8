using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Business
{
    public interface IPersonBusiness
    {
        // method Iterface
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
