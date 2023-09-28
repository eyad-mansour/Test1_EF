using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_EF.Models.Interfaces;
using test_EF.Models;

namespace test_EF.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnology _technology;

        public TechnologyController(ITechnology Technology)
        {
            _technology = Technology;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologies()
        {
            var list = await _technology.GetAllTechnologies();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
            Technology technology = await _technology.GetTechnology(id);
            return technology;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTechnology(int id, Technology technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }
            var UpdatedTechnology = await _technology.UpdateTechnology(id, technology);
            return Ok(UpdatedTechnology);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            await _technology.DeleteTechnology(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
        {
            await _technology.CreateTechnology(technology);
            return CreatedAtAction("GetTechnology", new { id = technology.Id}, technology);
        }
    }
}
