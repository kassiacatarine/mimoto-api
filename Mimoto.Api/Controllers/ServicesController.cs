using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mimoto.Application.Services.Common;
using Mimoto.Domain.Common;

namespace Mimoto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult<List<Service>> Get()
        {
            return _serviceService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetService")]
        public ActionResult<Service> Get([FromRoute] string id)
        {
            var service = _serviceService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public ActionResult<Service> Create(Service service)
        {
            _serviceService.Create(service);

            return CreatedAtRoute("GetService", new { id = service.Id.ToString() }, service);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromRoute] string id, Service serviceIn)
        {
            var service = _serviceService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            _serviceService.Update(id, serviceIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var service = _serviceService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            _serviceService.Remove(service.Id);

            return NoContent();
        }
    }
}