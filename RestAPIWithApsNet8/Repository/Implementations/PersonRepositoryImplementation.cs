using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Model.Context;

namespace RestAPIWithApsNet8.Repository.Implementations;

public class PersonRepositoryImplementation : IPersonRepository
{
    //private volatile int _count;
    private MySqlContext _context;

    public PersonRepositoryImplementation(MySqlContext context)
    {
        _context = context;
    }
    #region FindAll
    public List<Person> FindAll()
    {
        return _context.persons.ToList();
    }
    #endregion
    #region FindById
    public Person FindById(long id)
    {
        return _context.persons.SingleOrDefault(p => p.Id.Equals(id)); // pesquisar SingleOrDefault(p => p.Id.Equals(id))
    }
    #endregion
    #region Create
    public Person Create(Person person)
    {
        try
        {
            _context.Add(person);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
        return person;
    }
    #endregion
    #region Update
    public Person Update(Person person)
    {
        if (!Exists(person.Id)) return null;
        var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));
        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        return person;
    }
    #endregion
    #region Delete
    public void Delete(long id)
    {
        var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));
        if (result != null)
        {
            try
            {
                _context.persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    #endregion
    #region Exists
    public bool Exists(long id)
    {
        return _context.persons.Any(p => p.Id.Equals(id));
    }
    #endregion
}
