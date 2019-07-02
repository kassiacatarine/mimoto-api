using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mimoto.Application.Apps.Common;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Domain.Common;

namespace Mimoto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {
        private readonly AppService _appService;

        public AppsController(AppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public ActionResult<List<App>> Get()
        {
            return _appService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetApp")]
        public ActionResult<App> Get([FromRoute] string id)
        {
            var app = _appService.Get(id);

            if (app == null)
            {
                return NotFound();
            }

            return app;
        }

        [HttpPost("profile")]
        public ActionResult<AppProfileViewModel> Create([FromBody] AppProfileViewModel model)
        {
            var app = _appService.Create(model);

            return CreatedAtRoute("GetApp", new { id = app.Id.ToString() }, model);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromRoute] string id, App appIn)
        {
            var app = _appService.Get(id);

            if (app == null)
            {
                return NotFound();
            }

            _appService.Update(id, appIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var app = _appService.Get(id);

            if (app == null)
            {
                return NotFound();
            }

            _appService.Remove(app.Id);

            return NoContent();
        }
    }
}