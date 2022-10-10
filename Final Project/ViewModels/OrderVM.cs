using Final_Project.Models;
using System;
using System.Collections.Generic;

namespace Final_Project.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SaledAt { get; set; }
        public double TotalPrice { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Order> Orders { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
    }
}
