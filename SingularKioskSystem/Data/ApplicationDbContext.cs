using Microsoft.EntityFrameworkCore;
using SingularKioskSystem.Models;

namespace SingularKioskSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users and Wallets (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserID);

            // Users and Admins (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Admin)
                .WithOne(a => a.User)
                .HasForeignKey<Admin>(a => a.UserID);

            // Users and Carts (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Carts)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserID);

            // Users and Transactions (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transaction)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserID);

            // Wallets and Transactions (One-to-Many)
            modelBuilder.Entity<Wallet>()
                .HasMany(w => w.TransactionDetails)
                .WithOne(t => t.Wallet)
                .HasForeignKey(t => t.WalletID);

            // Users and Products (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID);

            // Products and ProductCategories (One-to-Many)
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryID);

            // Carts and Products (Many-to-Many)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts)
                .UsingEntity(j => j.ToTable("CartProducts"));

            // One-to-One Relationship between Cart and Transaction
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Transaction)
                .WithOne(t => t.Cart)
                .HasForeignKey<TransactionDetails>(t => t.CartID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
