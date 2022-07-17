

using CsvParserApp.Controllers;
using CsvParserApp.Models;
using CsvParserApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CsvParserAppTests.Services
{
    public class PersonServiceTests
    {
        private PersonManagementController? _controller;
        private Mock<IPersonManagementService>? _mockPersonManagementService;

        [SetUp]
        public void Setup()
        {
            _mockPersonManagementService = new Mock<IPersonManagementService>();
            _controller = new PersonManagementController(_mockPersonManagementService.Object);
        }

        [Test]
        public void GetAllPeople_Returns_All_People()
        {
            var data = GetTestData();

            var service = MockDBSet(data);
            var people = service.GetAllPeople();

            Assert.That(people.Count, Is.EqualTo(5));
            Assert.That(people[0].first_name, Is.EqualTo("Aleshia"));
            Assert.That(people[1].first_name, Is.EqualTo("Evan"));
            Assert.That(people[2].first_name, Is.EqualTo("France"));
        }

        [Test]
        public void GetPeopleWithEsqInCompanyName_Returns_People_With_Esq_In_CompanyName()
        {
            var data = GetTestData();

            var service = MockDBSet(data);
            var people = service.GetPeopleWithEsqInCompanyName();

            var result = people.Skip(1);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPeopleWhoLiveInDerbyshire_Returns_People_With_County_Derbyshire()
        {
            var data = GetTestData();

            var service = MockDBSet(data);
            var people = service.GetPeopleWhoLiveInDerbyshire();

            var result = people.Skip(1);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetPeopleWhoseHouseNumberIsThreeDigits_Returns_People_With_House_Number_Consisting_of_3_Digits_Only()
        {
            var data = GetTestData();

            var service = MockDBSet(data);
            var people = service.GetPeopleWhoseHouseNumberIsThreeDigits();

            var result = people.Skip(1);

            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetPeopleWhoseURLIsLongerThan35Chars_Returns_People_With_URL_Length_Greater_Than_35()
        {
            var data = GetTestData();

            var service = MockDBSet(data);
            var people = service.GetPeopleWhoseURLIsLongerThan35Chars();

            var result = people.Skip(1);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPeopleWhoLiveInPostCodeSingleDigit_Returns_People_With_PostCode_With_Single_Digit()
        {
            var data = GetTestData();
            var service = MockDBSet(data);
            var people = service.GetPeopleWhoLiveInPostCodeSingleDigit();

            var result = people.Skip(1);

            Assert.That(result.Count, Is.EqualTo(2));
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

        public PersonManagementService MockDBSet(IQueryable<Person> data)
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

            return new PersonManagementService(mockContext.Object);
        }
    }
}