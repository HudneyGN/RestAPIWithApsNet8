using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Hypermedia.Utils;

namespace RestAPIWithApsNet8.Business
{
    public interface IPersonBusiness
    {
        // method Iterface
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);


    }
}
