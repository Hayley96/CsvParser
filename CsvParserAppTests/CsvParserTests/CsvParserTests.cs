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
        private string path;
        private string fileName;
        private string delimeter;

        [SetUp]
        public void Setup()
        {
            _parser = new();
            fileName = "input.csv";
            path = @"D:\Data\" + fileName;
            delimeter = ",";
        }

        [Test]
        public void GetData_returns_All_FileData()
        {
            var result = _parser.GetData(path, delimeter);

            Assert.That(result.Count, Is.EqualTo(501));
        }


        [Test]
        public void GetHeaders_returns_All_FileHeaders()
        {
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

        [Test]
        public void Create_returns_An_Instance_Of_T()
        {
            var result = _parser.Create<Person>();

            Assert.That(result, Is.InstanceOf<Person>());
        }

        [Test]
        public void MapValuesToTypeTProperties_returns_An_Instance_Of_T_With_Correct_Property_Values()
        {
            var lines = _parser.GetData(path, delimeter);
            var headers = _parser.GetHeaders(lines, delimeter);
            List<PropertyInfo> props = _parser.GetSystemPropertiesOfT<Person>();

            var result = _parser.MapValuesToTypeTProperties<Person>(lines[1], delimeter, headers, props);

            Assert.That(result, Is.InstanceOf<Person>());
            Assert.That(result.first_name == "Aleshia");
        }
    }
}