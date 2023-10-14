using Loja.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ProductModel>()
            .Property(a => a.Name).HasMaxLength(50).IsRequired();
        builder.Entity<ProductModel>()
            .Property(a => a.Description).HasMaxLength(100);
        builder.Entity<ProductModel>()
            .Property(a => a.Quantity).HasMaxLength(5).IsRequired();
        builder.Entity<ProductModel>()
            .Property(a => a.Date).IsRequired();
    }
}