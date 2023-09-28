using System;
using Microsoft.EntityFrameworkCore;
using test_EF.Data;
using test_EF.Models.Interfaces;
namespace test_EF.Models.Services
{
    public class CourseServices : ICourse 
    {
        private SchoolDbContext _context;

        public CourseServices(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourse(int CourseId)
        {
            Course course = await GetCourse(CourseId);
            _context.Entry(course).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _context.Course.ToListAsync();
            return courses;
        }

        public async Task<Course> GetCourse(int CourseId)
        {
            Course course = await _context.Course.FindAsync(CourseId);
            return course;
        }

        public async Task<Course> UpdateCourse(int CourseId, Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}

