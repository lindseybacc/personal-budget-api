using System;

namespace BudgetHub.Models
{
    // This code defines a Category model for a budget management application.
    public class Category
    {
        public Guid categoryId { get; set; }
        public Guid userId { get; set; }
        public string name { get; set; }
        public decimal budgetLimit { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User user { get; set; }
    }
}
