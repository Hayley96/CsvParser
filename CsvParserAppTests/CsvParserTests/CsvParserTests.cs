using CsvParserApp.Models;
using CsvParserApp.Parser;
using Moq;
using Newtonsoft.Json;
using System.Reflection;

namespace CsvParserAppTests.CsvParserTests
{
    public class CsvParserTests
    {
        private CsvParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new();
        }

        [Test]
        public void GetData_returns_All_FileData()
        {
            string fileName = "input.csv";
            var path = @"D:\Data\" + fileName;
            string delimeter = ",";

            var result = _parser.GetData(path, delimeter);

            Assert.That(result.Count, Is.EqualTo(501));
        }


        [Test]
        public void GetHeaders_returns_All_FileHeaders()
        {
            string fileName = "input.csv";
            var path = @"D:\Data\" + fileName;
            string delimeter = ",";

            var lines = _parser.GetData(path, delimeter);
            var result = _parser.GetHeaders(lines, delimeter);

            Assert.That(result.Count, Is.EqualTo(11));
        }

        [Test]
        public void GetSystemPropertiesOfT_returns_All_Properties_Of_T()
        {
            List<PropertyInfo> result = _parser.GetSystemPropertiesOfT<Person>();

            Assert.That(result.Count, Is.EqualTo(12));
        }
    }
}