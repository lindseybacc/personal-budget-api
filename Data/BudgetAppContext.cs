using Microsoft.EntityFrameworkCore;
using BudgetHub.Models;

namespace BudgetHub.Data
{
    public class BudgetAppContext : DbContext
    {
        public BudgetAppContext(DbContextOptions<BudgetAppContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.userId);
            modelBuilder.Entity<User>()
                .Property(u => u.name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.password)
                .IsRequired()
                .HasMaxLength(100);

            // Configure Expense entity
            modelBuilder.Entity<Expense>()
                .HasKey(e => e.expenseId);
            modelBuilder.Entity<Expense>()
                .Property(e => e.category)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Expense>()
                .Property(e => e.amount)
                .IsRequired();
            modelBuilder.Entity<Expense>()
                .Property(e => e.date)
                .IsRequired();

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .HasKey(c => c.categoryId);
            modelBuilder.Entity<Category>()
                .Property(c => c.name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Category>()
                .Property(c => c.budgetLimit)
                .IsRequired();

            // Configure Receipt entity
            modelBuilder.Entity<Receipt>()
                .HasKey(r => r.ReceiptId);
            modelBuilder.Entity<Receipt>()
                .Property(r => r.ImageUrl)
                .IsRequired();
            modelBuilder.Entity<Receipt>()
                .Property(r => r.Amount)
                .IsRequired();
            modelBuilder.Entity<Receipt>()
                .Property(r => r.Date)
                .IsRequired();
        }
    }
}