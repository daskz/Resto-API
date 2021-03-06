﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resto.Services;
using Resto.Services.Services;
using Resto.Shared.Dtos;

namespace Resto.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HangoutsController : ControllerBase
    {
        private readonly ISimpleService<HangoutPlaceDto> _simpleService;

        public HangoutsController(ISimpleService<HangoutPlaceDto> simpleService)
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
        public IActionResult Post([FromBody] HangoutPlaceDto dto)
        {
            var id = _simpleService.Save(dto);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] HangoutPlaceDto dto)
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
