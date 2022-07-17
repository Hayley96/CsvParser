using CsvParserApp.Parser;

namespace CsvParserApp.Services
{
    public interface IParserManagementService
    {
        int CreatePeopleData(IParser parser);
    }
}
