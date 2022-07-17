using CsvParserApp.Models;

namespace CsvParserApp.Services
{
    public class PersonManagementService : IPersonManagementService
    {
        private readonly PersonContext _context;

        public PersonManagementService(PersonContext context)
        {
            _context = context;
        }

        public List<Person> GetAllPeople()
        {
            var people = _context.People!.ToList();
            return people;
        }      
    }
}