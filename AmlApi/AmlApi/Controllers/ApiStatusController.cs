// Copyright 2024 XLN Telecom, Inc.  All rights reserved.
// This computer source code and related instructions and comments are the unpublished
// confidential and proprietary information of XLN Telecom Ltd. and are protected under UK
// and foreign intellectual property laws. They may not be disclosed to, copied or used by
// any third party without the prior written consent of XLN Telecom Ltd.
// ----------------------------------------------------------------------------------------------------

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