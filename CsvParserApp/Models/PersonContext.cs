using Microsoft.EntityFrameworkCore;

namespace CsvParserApp.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }
        public virtual DbSet<Person>? People { get; set; }
    }
}