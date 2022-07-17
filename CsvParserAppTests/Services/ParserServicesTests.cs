using CsvParserApp.Models;
using CsvParserApp.Parser;
using CsvParserApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CsvParserAppTests.Services
{
    public class ParserServicesTests
    {
        private ParserManagementService _parserManagementService;
        private CsvParser? _parser;
        private PersonContext? _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PersonContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _parser = new ();
            _context = new (options);
            _parserManagementService = new(_context);
        }

        [Test]
        public void CreatePeopleData_Returns_All_Count_Of_People_Created()
        {

            var people = _parserManagementService.CreatePeopleData(_parser!);

            Assert.That(people, Is.EqualTo(500));
        }

        [Test]
        public void GetFilePath_Returns_All_Count_Of_People_Created()
        {
            var people = _parserManagementService.GetFilePath();

            Assert.That(people, Is.EqualTo(@"D:\Data\input.csv"));
        }

        private IQueryable<Person> GetTestData()
        {
            return new List<Person>
            {
                new Person()
                    {
                        first_name = "Aleshia",
                        last_name = "Tomkiewicz",
                        company_name = "Alan D Rosenburg Cpa Pc",
                        address = "147 Taylor St",
                        city = "St. Stephens Ward",
                        county = "Derbyshire",
                        postal = "C2 7PP",
                        phone1 = "01835-703597",
                        phone2 = "01944-369967",
                        email = "atomkiewicz@hotmail.com",
                        web = "http://www.alandrosenburgcpapc.co.uk",
                    },
                new Person()
                   {
                       first_name = "Evan",
                       last_name = "Zigomalas",
                       company_name = "Cap Gemini America",
                       address = "555 Binney St",
                       city = "Abbey Ward",
                       county = "Buckinghamshire",
                       postal = "H91 2AX",
                       phone1 = "01937-864715",
                       phone2 = "01714-737668",
                       email = "evan.zigomalas@gmail.com",
                       web = "http://www.capgeminiamerica.co.uk"
                   },
                new Person()
                    {
                        first_name = "France",
                        last_name = "Andrade",
                        company_name = "Elliott, John W Esq",
                        address = "8 Moor Place",
                        city = "East Southbourne and Tuckton W",
                        county = "Derbyshire",
                        postal = "B6 3BE",
                        phone1 = "01347-368222",
                        phone2 = "01935-821636",
                        email = "france.andrade@hotmail.com",
                        web = "http://www.elliottjohnwesq.co.uk"
                    },
                                new Person()
                   {
                       first_name = "Zoe",
                       last_name = "Zigomalas",
                       company_name = "Cap Gemini America",
                       address = "555 Binney St",
                       city = "Abbey Ward",
                       county = "Buckinghamshire",
                       postal = "H21 2AX",
                       phone1 = "01937-864715",
                       phone2 = "01714-737668",
                       email = "evan.zigomalas@gmail.com",
                       web = "http://www.capgeminiamerica.co.uk"
                   },
                new Person()
                   {
                       first_name = "Marvin",
                       last_name = "Zigomalas",
                       company_name = "Cap Gemini America",
                       address = "555 Binney St",
                       city = "Abbey Ward",
                       county = "Buckinghamshire",
                       postal = "SE21 2AX",
                       phone1 = "01937-864715",
                       phone2 = "01714-737668",
                       email = "evan.zigomalas@gmail.com",
                       web = "http://www.capgeminiamerica.co.uk"
                   },
            }.AsQueryable();
        }
        public ParserManagementService MockDBSet(IQueryable<Person> data)
        {
            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var options = new DbContextOptionsBuilder<PersonContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var mockContext = new Mock<PersonContext>(options);
            mockContext.Setup(c => c.People).Returns(mockSet.Object);

            return new ParserManagementService(mockContext.Object);
        }
    }
}