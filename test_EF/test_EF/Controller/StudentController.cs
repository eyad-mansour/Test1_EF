using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using test_EF.Models.Interfaces;
using test_EF.Models;

namespace test_EF.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent Student)
        {
            _student = Student;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var list = await _student.GetAllStudents();
            return Ok(list);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task <ActionResult<Student>> GetStudent(int id)
        {
            Student student = await _student.GetStudent(id);
            return student;
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _student.Create(student);
            return CreatedAtAction("GetStudent", new {id = student.Id}, student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(Student student, int id)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            var updatedStudent = await _student.UpdateStudent(id, student);
            return Ok(updatedStudent);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteStudent(int id)
        {
            await _student.DeleteStudent(id);
            return NoContent();
        }
    }
}
