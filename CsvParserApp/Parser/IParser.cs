namespace CsvParserApp.Parser
{
    public interface IParser
    {
        List<T> Parse<T>(string file, string delimeter) where T : new();
        List<string> GetData(string file, string delimiter);
    }
}
