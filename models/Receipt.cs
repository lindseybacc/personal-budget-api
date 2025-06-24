using System;

namespace BudgetApp.Models
{
    // This code defines a Receipt model for a budget management application.
    public class Receipt
    {
        public Guid ReceiptId { get; set; }     // Primary Key
        public Guid ExpenseId { get; set; }     // Foreign Key to Expense
        public string ImageUrl { get; set; } 
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public Expense Expense { get; set; }
    }
}
