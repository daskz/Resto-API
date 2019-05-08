using System;
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
        private readonly IHangoutService _hangoutService;

        public HangoutsController(IHangoutService hangoutService)
        {
            _hangoutService = hangoutService;
        }

        // GET: api/Hangouts
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hangoutService.Get());
        }

        // GET: api/Hangouts/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!_hangoutService.Exists(id))
                return BadRequest();

            return Ok(_hangoutService.Get(id));
        }

        // POST: api/Hangouts
        [HttpPost]
        public IActionResult Post([FromBody] HangoutPlaceDto dto)
        {
            var id = _hangoutService.Save(dto);
            return Ok(id);
        }

        // PUT: api/Hangouts/5
        [HttpPut]
        public IActionResult Put([FromBody] HangoutPlaceDto dto)
        {
            if (!_hangoutService.Exists(dto.Id))
                return BadRequest();

            _hangoutService.Save(dto);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_hangoutService.Exists(id))
                return BadRequest();
            
            _hangoutService.Delete(id);

            return Ok();
        }
    }
}
