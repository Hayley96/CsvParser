using System.Reflection;

namespace CsvParserApp.Parser
{
    public class CsvParser : IParser
    {
        public List<T> Parse<T>(string file, string delimeter) where T : new()
        {
            List<T> list = new();
            var lines = GetData(file, delimeter);
            var headers = GetHeaders(lines, delimeter);
            var properties = GetSystemPropertiesOfT<T>();
            return list;
        }

        public List<string> GetData(string file, string delimiter) =>
            File.ReadLines(file).ToList();

        public List<string> GetHeaders(List<string> lines, string delimeter) =>
            lines.First().Split(delimeter).ToList();

        public List<PropertyInfo> GetSystemPropertiesOfT<T>() =>
            typeof(T).GetProperties().ToList();
    }
}