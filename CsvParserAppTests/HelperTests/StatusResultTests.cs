using CsvParserApp.Helper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CsvParserAppTests.HelperTests
{
    public class StatusResultTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Result_Returns_Correct_ResponseType()
        {
            //Act
            var result = StatusResult.Result(HttpStatusCode.OK, $"500 records created");

            //Assert
            result.Should().BeOfType(typeof(ContentResult));
        }
        private static ActionResult GetContentresult()
        {
            return new ContentResult
            {
                Content = "Status Code: 200 OK: 500 records created",
                ContentType = "text/plain",
                StatusCode = 200
            };
        }
    }
}