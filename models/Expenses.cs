using System;

namespace BudgetHub.Models
{
    // This code defines an Expenses model for a budget management application.
    public class Expenses
    {
        public Guid expenseId { get; set; }
        public Guid userId { get; set; }
        public string category { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public string notes { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User user { get; set; }
    }
}