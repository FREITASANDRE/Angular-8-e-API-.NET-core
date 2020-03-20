using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UserController(UserBusiness pUserBusiness)
        {
            _userBusiness = pUserBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lResult = await _userBusiness.GetAll();

            return Ok(lResult);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLogin pUser)
        {
            var lResult = await _userBusiness.Login(pUser.Mail, pUser.Password);

            return Ok(lResult);
        }

    }
}
