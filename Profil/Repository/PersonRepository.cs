using Profil.DBContext;

namespace Profil.Repository;

public class PersonRepository
{
    private PersonContext _context;

    public PersonRepository(PersonContext context)
    {
        _context = context;
    }
    
    public Person AddPerson(Person person)
    {
        try
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}