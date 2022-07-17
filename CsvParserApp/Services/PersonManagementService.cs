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

        public List<Object> GetPeopleWithEsqInCompanyName()
        {
            var people = from p in _context.People
                         where p.company_name!.Contains("Esq")
                         select p.Id + "-" + p.first_name + " " + p.last_name + "-" + p.company_name;
            return PrepareResultString(people);
        }

        private static List<Object> PrepareResultString(IQueryable<string> people)
        {
            var result = people.ToList<Object>();
            result.Insert(0, "Count:" + people.Count());
            return result;
        }

        public List<Object> GetPeopleWhoLiveInDerbyshire()
        {
            var people = from p in _context.People
                         where p.county!.Equals("Derbyshire")
                         select p.Id + "-" + p.first_name + " " + p.last_name + "-" + p.company_name;
            return PrepareResultString(people);
        }
    }
}