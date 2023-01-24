using System.ComponentModel.DataAnnotations.Schema;

namespace Profil;

[Table("person")]
public class Person
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}