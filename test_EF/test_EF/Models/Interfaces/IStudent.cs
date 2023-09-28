using System;
namespace test_EF.Models.Interfaces
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudent(int StudentId);

        Task DeleteStudent(int StudentId);

        Task<Student> UpdateStudent(int StudentId, Student student);

        Task<Student> Create(Student student);
    }
}

