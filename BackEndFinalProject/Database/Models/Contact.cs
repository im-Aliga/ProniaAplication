﻿using BackEndFinalProject.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace BackEndFinalProject.Database.Models
{
    public class Contact : BaseEntity<int>, IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }   
        public string Message { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
