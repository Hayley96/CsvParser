using CsvParserApp.Models;

namespace CsvParserApp.Services
{
    public interface IPersonManagementService
    {
        List<Person> GetAllPeople();
        List<Object> GetPeopleWithEsqInCompanyName();
    }
}