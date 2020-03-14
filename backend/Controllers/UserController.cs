using System.Threading.Tasks;
using App_Api.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
