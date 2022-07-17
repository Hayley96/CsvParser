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
    }
}