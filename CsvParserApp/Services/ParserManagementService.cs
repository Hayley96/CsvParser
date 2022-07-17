using CsvParserApp.Models;
using CsvParserApp.Parser;
using Newtonsoft.Json;

namespace CsvParserApp.Services
{
    public class ParserManagementService : IParserManagementService
    {
        private readonly PersonContext _context;
        private List<Person>? _people;
        public ParserManagementService(PersonContext context)
        {
            _context = context;
        }
        public int CreatePeopleData(IParser parser)
        {
            var path = GetFilePath();
            var recs = parser.Parse<Person>(path, ",");
            var result = JsonConvert.SerializeObject(recs);
            _people = JsonConvert.DeserializeObject<List<Person>>(result);
            SaveToDB(_people!);
            return _people!.Count;
        }

        public string GetFilePath()
        {
            string fileName = "input.csv";
            return @"D:\Data\" + fileName;
        }

        public void SaveToDB(List<Person> people)
        {
            people.ForEach(person => _context.Add(person));
            _context.SaveChanges();
        }
    }
}
