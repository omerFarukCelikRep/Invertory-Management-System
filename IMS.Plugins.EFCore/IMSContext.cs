using IMS.CoreBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.Plugins.EFCore;

public class IMSContext : IdentityDbContext
{
    public IMSContext(DbContextOptions<IMSContext> options) : base(options) { }

    public virtual DbSet<Invertory> Invertories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductInvertory> ProductInvertories { get; set; }
    public virtual DbSet<InvertoryTransaction> InvertoryTransactions { get; set; }
    public virtual DbSet<ProductTransaction> ProductTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Invertory>()
            .HasKey(x => x.Id);

        builder.Entity<Product>()
            .HasKey(x => x.Id);

        builder.Entity<ProductInvertory>()
            .HasKey(x => new { x.ProductId, x.InvertoryId });

        builder.Entity<ProductInvertory>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductInvertories)
            .HasForeignKey(pi => pi.ProductId);

        builder.Entity<ProductInvertory>()
            .HasOne(pi => pi.Invertory)
            .WithMany(i => i.ProductInvertories)
            .HasForeignKey(pi => pi.InvertoryId);

        builder.Entity<InvertoryTransaction>()
            .HasKey(x => x.Id);

        builder.Entity<ProductTransaction>()
            .HasKey(x => x.Id);

        builder.Entity<Invertory>()
            .HasData(new Invertory()
            {
                Id = new Guid("B631C109-E664-46B9-B4B1-E9C66F4A746F"),
                Name = "Gas Engine",
                Price = 1000,
                Quantity = 1
            },
            new Invertory()
            {
                Id = new Guid("B79305BD-6F8B-4E25-9B29-C1187D76819E"),
                Name = "Body",
                Price = 400,
                Quantity = 1
            },
            new Invertory()
            {
                Id = new Guid("F1FD209E-1ACA-4A43-8E6B-4E83EDB3E89F"),
                Name = "Wheels",
                Price = 100,
                Quantity = 4
            },
            new Invertory()
            {
                Id = new Guid("069ED0AF-C09C-41FF-A93C-656D6A535C6D"),
                Name = "Seats",
                Price = 50,
                Quantity = 5
            },
            new Invertory()
            {
                Id = new Guid("9B2460C2-6C1B-4F7F-B31F-13AAEEB18BE9"),
                Name = "Electric Engine",
                Price = 8000,
                Quantity = 2
            },
            new Invertory()
            {
                Id = new Guid("D4C090C9-A51B-4792-8587-DD866E7E938C"),
                Name = "Battery",
                Price = 2500,
                Quantity = 5
            });

        builder.Entity<Product>()
            .HasData(new Product()
            {
                Id = new Guid("C7525FC0-BD28-447D-9885-814C0F508CDA"),
                Name = "Gas Car",
                Price = 20000,
                Quantity = 1
            },
            new Product()
            {
                Id = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                Name = "Electric Car",
                Price = 35000,
                Quantity = 1
            });

        builder.Entity<ProductInvertory>()
            .HasData(new ProductInvertory
            {
                InvertoryId = new Guid("B631C109-E664-46B9-B4B1-E9C66F4A746F"),
                ProductId = new Guid("C7525FC0-BD28-447D-9885-814C0F508CDA"),
                InvertoryQuantity = 1
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("B79305BD-6F8B-4E25-9B29-C1187D76819E"),
                ProductId = new Guid("C7525FC0-BD28-447D-9885-814C0F508CDA"),
                InvertoryQuantity = 1
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("F1FD209E-1ACA-4A43-8E6B-4E83EDB3E89F"),
                ProductId = new Guid("C7525FC0-BD28-447D-9885-814C0F508CDA"),
                InvertoryQuantity = 4
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("069ED0AF-C09C-41FF-A93C-656D6A535C6D"),
                ProductId = new Guid("C7525FC0-BD28-447D-9885-814C0F508CDA"),
                InvertoryQuantity = 5
            });

        builder.Entity<ProductInvertory>()
            .HasData(new ProductInvertory
            {
                InvertoryId = new Guid("9B2460C2-6C1B-4F7F-B31F-13AAEEB18BE9"),
                ProductId = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                InvertoryQuantity = 1
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("B79305BD-6F8B-4E25-9B29-C1187D76819E"),
                ProductId = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                InvertoryQuantity = 1
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("F1FD209E-1ACA-4A43-8E6B-4E83EDB3E89F"),
                ProductId = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                InvertoryQuantity = 4
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("069ED0AF-C09C-41FF-A93C-656D6A535C6D"),
                ProductId = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                InvertoryQuantity = 5
            },
            new ProductInvertory
            {
                InvertoryId = new Guid("D4C090C9-A51B-4792-8587-DD866E7E938C"),
                ProductId = new Guid("003A84AB-5D76-49C4-B944-483BF259AE09"),
                InvertoryQuantity = 1
            });

        base.OnModelCreating(builder);
    }
}
