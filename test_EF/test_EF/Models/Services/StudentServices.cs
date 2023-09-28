using System;
using Microsoft.EntityFrameworkCore;
using test_EF.Data;
using test_EF.Models.Interfaces;

namespace test_EF.Models.Services
{
    public class StudentServices : IStudent
    {
        private SchoolDbContext _context;

        public StudentServices(SchoolDbContext  context)
        {
            _context = context;
        }

        public async Task<Student> Create(Student student)
        {
            _context.Entry(student).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudent(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(int id)
        {
            Student student = await GetStudent(id);
            _context.Entry(student).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

