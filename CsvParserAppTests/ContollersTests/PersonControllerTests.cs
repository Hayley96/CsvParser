using CsvParserApp.Controllers;
using CsvParserApp.Models;
using CsvParserApp.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CsvParserAppTests.ContollersTests
{
    public class PersonControllerTests
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
        public void GetPeople_Returns_List_of_Person()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetAllPeople()).Returns(GetTestPeople());

            //Act
            var result = _controller!.GetPeople();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Person>>));
            result.Value!.Count().Should().Be(3);
        }

        [Test]
        public void GetPeopleWithCompanyNameContainingEsq_Returns_List_of_Objects()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetPeopleWithEsqInCompanyName()).Returns(GetTestObject());

            //Act
            var result = _controller!.GetPeopleWithCompanyNameContainingEsq();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Object>>));
        }

        [Test]
        public void GetPeopleFromDerbyshire_Returns_List_of_Objects()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetPeopleWhoLiveInDerbyshire()).Returns(GetTestObject());

            //Act
            var result = _controller!.GetPeopleFromDerbyshire();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Object>>));
        }

        [Test]
        public void GetPeopleWhoseHouseNumberIsExactlyThreeDigits_Returns_List_of_Objects()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetPeopleWhoseHouseNumberIsThreeDigits()).Returns(GetTestObject());

            //Act
            var result = _controller!.GetPeopleWhoseHouseNumberIsExactlyThreeDigits();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Object>>));
        }

        [Test]
        public void GetPeopleWhoseURLLengthGreaterThan35_Returns_List_of_Objects()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetPeopleWhoseURLIsLongerThan35Chars()).Returns(GetTestObject());

            //Act
            var result = _controller!.GetPeopleWhoseURLLengthGreaterThan35();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Object>>));
        }

        [Test]
        public void GetPeopleWhoLiveInPostcodeWithSingleDigitValue_Returns_List_of_Objects()
        {
            //Arange
            _mockPersonManagementService!.Setup(b => b.GetPeopleWhoLiveInPostCodeSingleDigit()).Returns(GetTestObject());

            //Act
            var result = _controller!.GetPeopleWhoLiveInPostcodeWithSingleDigitValue();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Object>>));
        }

        private static List<Person> GetTestPeople()
        {
            return new List<Person>
            {
                new Person() { },
                new Person() { },
                new Person() { },
            };
        }

        private static List<Object> GetTestObject()
        {
            return new List<Object>
            {
                new Person() { },
                new Person() { },
                new Person() { },
            };
        }
    }
}
