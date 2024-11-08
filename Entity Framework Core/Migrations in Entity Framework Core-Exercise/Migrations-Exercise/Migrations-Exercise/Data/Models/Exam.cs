﻿using System;
using System.Collections.Generic;

namespace Migrations_Exercise.Data.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
