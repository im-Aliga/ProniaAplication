﻿using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class Tag : BaseEntity<int>, IAuditable
    {
        public string TagName{ get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime UpdatedAt { get; set ; }
        List<PlantTag> Tags { get; set; }
    }
}
