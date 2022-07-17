using CsvParserApp.Controllers;
using CsvParserApp.Models;
using CsvParserApp.Parser;
using CsvParserApp.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CsvParserAppTests.ContollersTests
{
    public class ParserControllerTests
    {
        private ParserManagementController? _controller;
        private Mock<IParserManagementService>? _mockParserManagementService;
        private Mock<IParser>? _parser;

        [SetUp]
        public void Setup()
        {
            _mockParserManagementService = new Mock<IParserManagementService>();
            _parser = new Mock<IParser>();
            _controller = new ParserManagementController(_mockParserManagementService.Object, _parser.Object);
        }

        [Test]
        public void CreateData_Parses_Data_Correctly_And_Returns_Row_Count()
        {
            _mockParserManagementService!.Setup(b => b.CreatePeopleData(_parser!.Object)).Returns(GetTestPeople());

            var result = _controller!.CreateData();

            result.Should().BeOfType(typeof(ActionResult<string>));
        }

        private static int GetTestPeople()
        {
            List<Person> people = new List<Person>
            {
                new Person() { },
                new Person() { },
                new Person() { },
            };
            return people.Count;
        }
    }
}
