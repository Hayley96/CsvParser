using CsvParserApp.Helper;
using CsvParserApp.Parser;
using CsvParserApp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CsvParserApp.Controllers
{
    [ApiController]
    [Route("ap1/v1/parser")]
    public class ParserManagementController
    {
        private readonly IParserManagementService? _parserManagementService;
        private readonly IParser? _parser;

        public ParserManagementController(IParserManagementService? parserManagementService, IParser parser)
        {
            _parserManagementService = parserManagementService;
            _parser = parser;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Extract data from file and load to database")]
        //GET: api/v1/parser
        public ActionResult<string> CreateData()
        {
            var result = _parserManagementService!.CreatePeopleData(_parser!);
            return result > 0 ? StatusResult.Result(HttpStatusCode.OK, $"{result} records created") :
                StatusResult.Result(HttpStatusCode.BadRequest, $"Oops, it appears something went wrong...Please try again");
        }
    }
}