using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resto.Services;
using Resto.Services.Services;
using Resto.Shared.Dtos;

namespace Resto.API.Controllers
{
    [Authorize]
    [Route("api/categories")]
    public class PlaceCategoryController : ControllerBase
    {
        private readonly ISimpleService<PlaceCategoryDto> _simpleService;

        public PlaceCategoryController(ISimpleService<PlaceCategoryDto> simpleService)
        {
            _simpleService = simpleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_simpleService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!_simpleService.Exists(id))
                return BadRequest();

            return Ok(_simpleService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlaceCategoryDto dto)
        {
            var id = _simpleService.Save(dto);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PlaceCategoryDto dto)
        {
            if (!_simpleService.Exists(dto.Id))
                return BadRequest();

            _simpleService.Save(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_simpleService.Exists(id))
                return BadRequest();
            
            _simpleService.Delete(id);

            return Ok();
        }
    }
}
