using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Profil.DBContext;

public class PersonContext : DbContext 
{
    
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; }

    
}