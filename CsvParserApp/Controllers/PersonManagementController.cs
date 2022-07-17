using CsvParserApp.Models;
using CsvParserApp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CsvParserApp.Controllers
{
    [ApiController]
    [Route("api/v1/people/[action]")]
    public class PersonManagementController
    {
        private readonly IPersonManagementService? _personManagementService;

        public PersonManagementController(IPersonManagementService? personManagementService)
        {
            _personManagementService = personManagementService;
        }

        [HttpGet]
        [ActionName("Get all people")]
        [SwaggerOperation(Summary = "Get all people")]
        //GET: api/v1/people
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            return _personManagementService!.GetAllPeople();
        }

        [HttpGet]
        [ActionName("Get people with 'Esq' in Company Name")]
        [SwaggerOperation(Summary = "Get people with 'Esq' in Company Name")]
        //GET: api/v1/people/
        public ActionResult<IEnumerable<Object>> GetPeopleWithCompanyNameContainingEsq()
        {
            return _personManagementService!.GetPeopleWithEsqInCompanyName();
        }

        [HttpGet]
        [ActionName("Get people from Derbyshire")]
        [SwaggerOperation(Summary = "Get people from Derbyshire")]
        //GET: api/v1/people/
        public ActionResult<IEnumerable<Object>> GetPeopleFromDerbyshire()
        {
            return _personManagementService!.GetPeopleWhoLiveInDerbyshire();
        }

        [HttpGet]
        [ActionName("Get people whose house number is exactly 3 digits")]
        [SwaggerOperation(Summary = "Get people whose house number is exactly 3 digits")]
        //GET: api/v1/people/
        public ActionResult<IEnumerable<Object>> GetPeopleWhoseHouseNumberIsExactlyThreeDigits()
        {
            return _personManagementService!.GetPeopleWhoseHouseNumberIsThreeDigits();
        }

        [HttpGet]
        [ActionName("Get people whose website URL length is greater than 35 characters")]
        [SwaggerOperation(Summary = "Get people whose website URL length is greater than 35 characters")]
        //GET: api/v1/people/
        public ActionResult<IEnumerable<Object>> GetPeopleWhoseURLLengthGreaterThan35()
        {
            return _personManagementService!.GetPeopleWhoseURLIsLongerThan35Chars();
        }
    }
}