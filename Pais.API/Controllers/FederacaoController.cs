using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pais.Application.Models;
using Pais.Application.Services;

namespace Pais.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FederacaoController : ControllerBase
    {
        private readonly FederacaoService federacaoService;

        public FederacaoController(FederacaoService federacaoService)
        {
            this.federacaoService = federacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FederacaoCreate command)
        {
            var id = await federacaoService.Handle(command, new System.Threading.CancellationToken());
            return Created($"api/federacao/{id}", id);
        }
    }
}
