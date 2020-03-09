﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName {
            get { return LastName + ", " + FirstMidName; }
        }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}