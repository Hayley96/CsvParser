using CsvParserApp.Models;

namespace CsvParserApp.Services
{
    public interface IPersonManagementService
    {
        List<Person> GetAllPeople();
        List<Object> GetPeopleWithEsqInCompanyName();
        List<Object> GetPeopleWhoLiveInDerbyshire();
        List<Object> GetPeopleWhoseHouseNumberIsThreeDigits();
        List<Object> GetPeopleWhoseURLIsLongerThan35Chars();
        List<Object> GetPeopleWhoLiveInPostCodeSingleDigit();
    }
}