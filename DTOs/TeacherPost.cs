﻿using school_holistic.Models;
using System.ComponentModel.DataAnnotations;

namespace school_holistic.DTOs
{
    public class TeacherPost
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? SubjectId { get; set; }
    }
}
