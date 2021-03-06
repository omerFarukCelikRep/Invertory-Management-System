// <auto-generated />
using System;
using IMS.Plugins.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    [DbContext(typeof(IMSContext))]
    [Migration("20220212221204_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IMS.CoreBusiness.Invertory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invertories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b631c109-e664-46b9-b4b1-e9c66f4a746f"),
                            Name = "Gas Engine",
                            Price = 1000.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("b79305bd-6f8b-4e25-9b29-c1187d76819e"),
                            Name = "Body",
                            Price = 400.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("f1fd209e-1aca-4a43-8e6b-4e83edb3e89f"),
                            Name = "Wheels",
                            Price = 100.0,
                            Quantity = 4
                        },
                        new
                        {
                            Id = new Guid("069ed0af-c09c-41ff-a93c-656d6a535c6d"),
                            Name = "Seats",
                            Price = 50.0,
                            Quantity = 5
                        },
                        new
                        {
                            Id = new Guid("9b2460c2-6c1b-4f7f-b31f-13aaeeb18be9"),
                            Name = "Electric Engine",
                            Price = 8000.0,
                            Quantity = 2
                        },
                        new
                        {
                            Id = new Guid("d4c090c9-a51b-4792-8587-dd866e7e938c"),
                            Name = "Battery",
                            Price = 2500.0,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("IMS.CoreBusiness.InvertoryTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvertoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PONumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvertoryId");

                    b.ToTable("InvertoryTransactions");
                });

            modelBuilder.Entity("IMS.CoreBusiness.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c7525fc0-bd28-447d-9885-814c0f508cda"),
                            IsActive = true,
                            Name = "Gas Car",
                            Price = 20000.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            IsActive = true,
                            Name = "Electric Car",
                            Price = 35000.0,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("IMS.CoreBusiness.ProductInvertory", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvertoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InvertoryQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "InvertoryId");

                    b.HasIndex("InvertoryId");

                    b.ToTable("ProductInvertories");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("c7525fc0-bd28-447d-9885-814c0f508cda"),
                            InvertoryId = new Guid("b631c109-e664-46b9-b4b1-e9c66f4a746f"),
                            InvertoryQuantity = 1
                        },
                        new
                        {
                            ProductId = new Guid("c7525fc0-bd28-447d-9885-814c0f508cda"),
                            InvertoryId = new Guid("b79305bd-6f8b-4e25-9b29-c1187d76819e"),
                            InvertoryQuantity = 1
                        },
                        new
                        {
                            ProductId = new Guid("c7525fc0-bd28-447d-9885-814c0f508cda"),
                            InvertoryId = new Guid("f1fd209e-1aca-4a43-8e6b-4e83edb3e89f"),
                            InvertoryQuantity = 4
                        },
                        new
                        {
                            ProductId = new Guid("c7525fc0-bd28-447d-9885-814c0f508cda"),
                            InvertoryId = new Guid("069ed0af-c09c-41ff-a93c-656d6a535c6d"),
                            InvertoryQuantity = 5
                        },
                        new
                        {
                            ProductId = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            InvertoryId = new Guid("9b2460c2-6c1b-4f7f-b31f-13aaeeb18be9"),
                            InvertoryQuantity = 1
                        },
                        new
                        {
                            ProductId = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            InvertoryId = new Guid("b79305bd-6f8b-4e25-9b29-c1187d76819e"),
                            InvertoryQuantity = 1
                        },
                        new
                        {
                            ProductId = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            InvertoryId = new Guid("f1fd209e-1aca-4a43-8e6b-4e83edb3e89f"),
                            InvertoryQuantity = 4
                        },
                        new
                        {
                            ProductId = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            InvertoryId = new Guid("069ed0af-c09c-41ff-a93c-656d6a535c6d"),
                            InvertoryQuantity = 5
                        },
                        new
                        {
                            ProductId = new Guid("003a84ab-5d76-49c4-b944-483bf259ae09"),
                            InvertoryId = new Guid("d4c090c9-a51b-4792-8587-dd866e7e938c"),
                            InvertoryQuantity = 1
                        });
                });

            modelBuilder.Entity("IMS.CoreBusiness.ProductTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<string>("SalesOrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTransactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("IMS.CoreBusiness.InvertoryTransaction", b =>
                {
                    b.HasOne("IMS.CoreBusiness.Invertory", "Invertory")
                        .WithMany()
                        .HasForeignKey("InvertoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invertory");
                });

            modelBuilder.Entity("IMS.CoreBusiness.ProductInvertory", b =>
                {
                    b.HasOne("IMS.CoreBusiness.Invertory", "Invertory")
                        .WithMany("ProductInvertories")
                        .HasForeignKey("InvertoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.CoreBusiness.Product", "Product")
                        .WithMany("ProductInvertories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invertory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IMS.CoreBusiness.ProductTransaction", b =>
                {
                    b.HasOne("IMS.CoreBusiness.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IMS.CoreBusiness.Invertory", b =>
                {
                    b.Navigation("ProductInvertories");
                });

            modelBuilder.Entity("IMS.CoreBusiness.Product", b =>
                {
                    b.Navigation("ProductInvertories");
                });
#pragma warning restore 612, 618
        }
    }
}
