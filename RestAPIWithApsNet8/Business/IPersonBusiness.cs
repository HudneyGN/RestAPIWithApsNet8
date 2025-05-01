using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Business
{
    public interface IPersonBusiness
    {
        // method Iterface
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
