using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Federations.Domain.Entities;
using Federations.Domain.Models;
using Federations.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Federations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FederationsController : ControllerBase
    {
        private readonly IFederationService _service;

        public FederationsController(IFederationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<FederationModel>> Get()
        {
            var federations = await _service.Find();

            if (federations == null || federations.Count() <= 0)
                return null;

            return federations;
        }

        [HttpGet("{id}")]
        public async Task<FederationModel> Get(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<FederationModel> Post([FromBody] CreateFederation value)
        {
            return await _service.Add(value);
        }

        [HttpPut("{id}")]
        public async Task<FederationModel> Put(string id, [FromBody] CreateFederation value)
        {
            var command = new UpdateFederation
            {
                Id = id,
                Name = value.Name,
            };

            return await _service.Update(command);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.Remove(id);

            return Ok();
        }
    }
}
