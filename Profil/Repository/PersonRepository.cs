using Profil.DBContext;

namespace Profil.Repository;

public class PersonRepository
{
    private PersonContext _context;

    public PersonRepository(PersonContext context)
    {
        _context = context;
    }
    
    public async Task<Person> AddPerson(Person person)
    {
        try
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}