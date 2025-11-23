using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;

namespace PhoneStore.Data
{
    public class PhoneStoreContext : DbContext
    {
        public PhoneStoreContext(DbContextOptions<PhoneStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Phone)
                .WithMany()
                .HasForeignKey(od => od.PhoneId);
            
            // Seed dữ liệu mẫu - Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Flagship", Description = "Điện thoại cao cấp" },
                new Category { Id = 2, Name = "Mid-range", Description = "Điện thoại tầm trung" },
                new Category { Id = 3, Name = "Budget", Description = "Điện thoại giá rẻ" }
            );

            // Seed dữ liệu mẫu - Users
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    Username = "admin", 
                    Password = "admin123", 
                    FullName = "Administrator",
                    Email = "admin@cloudshop.vn",
                    Phone = "0123456789",
                    IsAdmin = true,
                    CreatedAt = DateTime.Now
                }
            );
            
            // Seed dữ liệu mẫu - Phones
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    Name = "iPhone 15 Pro Max",
                    Brand = "Apple",
                    Price = 29990000,
                    Description = "iPhone 15 Pro Max với chip A17 Pro mạnh mẽ",
                    ImageUrl = "/images/iphone15.jpg",
                    Stock = 50,
                    Specifications = "6.7 inch, 256GB, Camera 48MP"
                },
                new Phone
                {
                    Id = 2,
                    Name = "Samsung Galaxy S24 Ultra",
                    Brand = "Samsung",
                    Price = 26990000,
                    Description = "Galaxy S24 Ultra với S Pen tích hợp",
                    ImageUrl = "/images/s24ultra.jpg",
                    Stock = 40,
                    Specifications = "6.8 inch, 256GB, Camera 200MP"
                },
                new Phone
                {
                    Id = 3,
                    Name = "Xiaomi 14 Pro",
                    Brand = "Xiaomi",
                    Price = 18990000,
                    Description = "Xiaomi 14 Pro camera Leica chuyên nghiệp",
                    ImageUrl = "/images/xiaomi14.jpg",
                    Stock = 60,
                    Specifications = "6.73 inch, 256GB, Camera 50MP"
                }
            );
        }
    }
}
