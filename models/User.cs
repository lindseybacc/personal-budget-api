using System;
using System.Collections;

namespace BudgetApp.Models
{
    // This code defines a User model for a budget management application.
    public class User
    {
        public Guid userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public List<Expense> expenses { get; set; } = new List<Expense>();
        public List<Category> categories { get; set; } = new List<Category>();
    }
 }