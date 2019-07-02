using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Application.Services.Common;
using Mimoto.Domain.Common;

namespace Mimoto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get([FromRoute] string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("profile")]
        public ActionResult<UserProfileViewModel> Create([FromBody] UserProfileViewModel model)
        {
            var user = _userService.Create(model);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, model);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromRoute] string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}