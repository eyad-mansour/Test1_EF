using System;
namespace test_EF.Models
{
    public class Transcript
    {
        public int Id{ get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public double Grade { get; set; }

        public bool Passed { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}

