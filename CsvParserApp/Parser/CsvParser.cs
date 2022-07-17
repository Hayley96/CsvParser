using System.Reflection;
using System.Text.RegularExpressions;

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
            lines.Skip(1).ToList().ForEach(l => list.Add(MapValuesToTypeTProperties<T>(l, delimeter, headers, properties)));
            return list;
        }

        public List<string> GetData(string file, string delimiter) =>
            File.ReadLines(file).ToList();

        public List<string> GetHeaders(List<string> lines, string delimeter) =>
            lines.First().Split(delimeter).ToList();

        public List<PropertyInfo> GetSystemPropertiesOfT<T>() =>
            typeof(T).GetProperties().ToList();

        public virtual T Create<T>() where T : new() =>
            new T();

        public T MapValuesToTypeTProperties<T>(string line, string delimeter, List<string> columnNames, List<PropertyInfo> properties) where T : new()
        {
            T obj = Create<T>();
            List<string> cells = new();
            var fieldValues = Regex.Split(line, $"{delimeter}(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").ToList();
            fieldValues.ForEach(field => cells.Add(field.Replace("\"", "")));
            int index = 0;

            columnNames.ForEach(column =>
            {
                var prop = properties.SingleOrDefault(p => p.Name == column);
                Type propertyType = prop!.PropertyType;
                var value = cells[index++];
                prop.SetValue(obj, Convert.ChangeType(value, propertyType));
            });

            return obj;
        }
    }
}