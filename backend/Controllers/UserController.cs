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

        [HttpPost]
        [Route("getall")]
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

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> Update(User pUser)
        {
            var lResult = await _userBusiness.Update(pUser);

            return Ok(lResult);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(User pUser)
        {
            var lResult = await _userBusiness.Create(pUser);

            return Ok(lResult);
        }

        [HttpPost]
        [Route("getbyid/{pId:int}")]
        public async Task<ActionResult> GetById(int pId)
        {
            var lResult = await _userBusiness.GetById(pId);

            return Ok(lResult);
        }

    }
}
