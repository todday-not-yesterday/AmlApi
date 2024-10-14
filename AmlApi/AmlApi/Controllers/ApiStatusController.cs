using AmlApi.Business.Getters;

namespace AmlApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using AmlApi.Business.Getters;

    [Route("[controller]")]
    public class ApiStatusController : Controller
    {
        private readonly IGetUser getUser;

        public ApiStatusController(IGetUser getUser)
        {
            this.getUser = getUser;
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
        
        /// <summary>
        /// Checks that the API is running
        /// </summary>
        /// <returns>Status of API</returns>
        /// <response code="200">API Running OK</response>
        [HttpGet("GetUser")]
        public IActionResult User()
        {
            return new OkObjectResult(this.getUser.Get());
        }
    }
}