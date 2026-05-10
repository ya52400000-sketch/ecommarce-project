using ecommarce.DAL.Configurations;
using ecommarce.DAL.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommarce.DAL.data;

public class Appdbcontext : IdentityDbContext<AppUser, IdentityRole, string>
{
public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
    {
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> orderItems => Set<OrderItem>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new CategorytypeConfiguration().Configure(modelBuilder.Entity<Category>());
        new ProductTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        new OrderTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        new CartTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
        new CartItemTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
    }

}
