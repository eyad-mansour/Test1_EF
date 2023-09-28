using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_EF.Models;
using test_EF.Models.Interfaces;

namespace test_EF.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;

        public CoursesController(ICourse Course)
        {
            _course = Course;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoureses()
        {
            var list = await _course.GetAllCourses();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            Course course = await _course.GetCourse(id);
            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(Course course)
        {
            await _course.CreateCourse(course);
            return CreatedAtAction("GetCourse",new {id = course.Id},course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            var UpdatedCourse = await _course.UpdateCourse(id, course);
            return Ok(UpdatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _course.DeleteCourse(id);
            return NoContent();
        }

    }
}
