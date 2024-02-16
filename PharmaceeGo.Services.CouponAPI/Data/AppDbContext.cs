using Microsoft.EntityFrameworkCore;
using PharmaceeGo.Services.CouponAPI.Models;

namespace PharmaceeGo.Services.CouponAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = 1,
            CouponCode = "2024FEB",
            DiscountAmount = 20,
            MinAmount = 30
        });
        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = 2,
            CouponCode = "2024Q1",
            DiscountAmount = 10,
            MinAmount = 20
        });
    }
}