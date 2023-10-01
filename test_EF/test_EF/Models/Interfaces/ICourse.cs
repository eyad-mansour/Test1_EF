using System;
namespace test_EF.Models.Interfaces
{
    public interface ICourse
    {
        Task<Course> GetCourse(int CourseId);

        Task<List<Course>> GetAllCourses();

        Task DeleteCourse(int CourseId);

        Task<Course> UpdateCourse(int CourseId, Course course);

        Task<Course> CreateCourse(Course course);

    }
}

