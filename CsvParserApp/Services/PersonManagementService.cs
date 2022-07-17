using CsvParserApp.Models;

namespace CsvParserApp.Services
{
    public class PersonManagementService : IPersonManagementService
    {
        private readonly PersonContext _context;
        public List<string>? peopleList { get; private set; } = new();

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

        public List<Object> GetPeopleWhoseHouseNumberIsThreeDigits()
        {
            var people = from p in _context.People
                         where p.address!.Substring(0, p.address.IndexOf(" ")).Length == 3
                         select p.Id + "-" + p.first_name + " " + p.last_name + "-" + p.company_name;
            return PrepareResultString(people);
        }

        public List<Object> GetPeopleWhoseURLIsLongerThan35Chars()
        {
            var people = from p in _context.People
                         where p.web!.Length > 35
                         select p.Id + "-" + p.first_name + " " + p.last_name + "-" + p.company_name;
            return PrepareResultString(people);
        }

        public List<Object> GetPeopleWhoLiveInPostCodeSingleDigit()
        {
            var peopleraw = _context.People!.ToList();
            foreach (var item in peopleraw)
                if (item.postal!.Substring(0, item.postal.IndexOf(" ")).Count(i => Char.IsDigit(i)) == 1)
                    peopleList!.Add(item.Id + "-" + item.first_name + " " + item.last_name + "-" + item.company_name);
            return PrepareResultString(peopleList!.AsQueryable());
        }
    }
}