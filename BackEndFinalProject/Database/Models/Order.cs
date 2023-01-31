﻿using BackEndFinalProject.Database.Models.Common;
using BackEndFinalProject.Database.Models.Enums;
namespace BackEndFinalProject.Database.Models
{
    public class Order : BaseEntity<string>, IAuditable
    {
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
         
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public List<OrderProduct>? OrderProducts { get; set; }
    }
}
