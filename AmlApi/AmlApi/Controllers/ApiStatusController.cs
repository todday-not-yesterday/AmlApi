using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;

namespace AmlApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class ApiStatusController : Controller
    {
        private readonly IDataContext dataContext;

        public ApiStatusController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
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