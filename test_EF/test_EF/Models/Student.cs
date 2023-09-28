﻿using System;
using System.ComponentModel.DataAnnotations;

namespace test_EF.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
            
    }
}

