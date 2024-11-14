using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;

namespace AmlApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class ApiStatusController : Controller
    {
        private readonly IDataContextFactory _dataContextFactory;

        public ApiStatusController(IDataContextFactory dataContextFactory)
        {
            this._dataContextFactory = dataContextFactory;
        }

        /// <summary>
        /// Checks that the API is running
        /// </summary>
        /// <returns>Status of API</returns>
        /// <response code="200">API Running OK</response>
        [HttpGet("Status")]
        public IActionResult Status()
        {
            return new OkObjectResult("Success");
        }
    }
}