﻿using System;
using System.Collections.Generic;

namespace Migrations_Exercise.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
