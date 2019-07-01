using Microsoft.AspNetCore.Mvc;
using Mimoto.Application.Services.Common;
using Mimoto.Domain.Common;
using Mimoto.Api;
using Mimoto.Api.Helpers;
using System;

namespace Mimoto.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly UserService _userService;
        public OAuthController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<string> Get([FromQuery] string email, string senha)
        {
            Console.WriteLine(email + senha);
            var user = _userService.VerifySignIn(email, senha);
            Console.WriteLine(user);
            if (user == null)
            {
                return NotFound();
            }


            var tokenBuilder = TokenBuilder.BuildToken(user);


            return tokenBuilder;
        }
    }
}