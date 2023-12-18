﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using comic.Models;

#nullable disable

namespace comic.Migrations
{
    [DbContext(typeof(ComicContext))]
    partial class ComicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductAuthor", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.HasKey("ProductId", "AuthorId")
                        .HasName("PK__product___AF676B499A35D847");

                    b.HasIndex("AuthorId");

                    b.ToTable("product_authors", (string)null);
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("ProductId", "TagId")
                        .HasName("PK__product___332B17DE39FB355A");

                    b.HasIndex("TagId");

                    b.ToTable("product_tags", (string)null);
                });

            modelBuilder.Entity("comic.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("author_name");

                    b.HasKey("AuthorId")
                        .HasName("PK__authors__86516BCFCF836665");

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("comic.Models.Cart", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductId")
                        .HasName("PK__cart__FDCE10D0D4976EEE");

                    b.HasIndex("UserId");

                    b.ToTable("cart", (string)null);
                });

            modelBuilder.Entity("comic.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("PK__categori__D54EE9B4E8AB0DFE");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("comic.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("image_name");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("ImageId")
                        .HasName("PK__images__DC9AC955BB180C51");

                    b.HasIndex("ProductId");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("comic.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int")
                        .HasColumnName("order_total");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("payment_id");

                    b.Property<int>("ShippingMethodId")
                        .HasColumnType("int")
                        .HasColumnName("shipping_method_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId")
                        .HasName("PK__orders__4659622922BB2BA9");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ShippingMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("comic.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK__order_de__022945F681B6D06E");

                    b.HasIndex("ProductId");

                    b.ToTable("order_details", (string)null);
                });

            modelBuilder.Entity("comic.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderStatusId"));

                    b.Property<string>("OrderStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("order_status_name");

                    b.HasKey("OrderStatusId")
                        .HasName("PK__order_st__A499CF236A94B87F");

                    b.ToTable("order_statuses", (string)null);
                });

            modelBuilder.Entity("comic.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("payment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("payment_name");

                    b.HasKey("PaymentId")
                        .HasName("PK__payments__ED1FC9EA3214F853");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("comic.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(sysdatetime())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("Inventory")
                        .HasColumnType("int")
                        .HasColumnName("inventory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("publisher_id");

                    b.Property<int>("StoreOwnerId")
                        .HasColumnType("int")
                        .HasColumnName("store_owner_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("(sysdatetime())");

                    b.HasKey("ProductId")
                        .HasName("PK__products__47027DF5E420AB95");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("StoreOwnerId");

                    b.ToTable("products", null, t =>
                        {
                            t.HasTrigger("AutoUpdateProductUpdatedAt");
                        });
                });

            modelBuilder.Entity("comic.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("publisher_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("publisher_name");

                    b.HasKey("PublisherId")
                        .HasName("PK__publishe__3263F29D76BB40CF");

                    b.ToTable("publishers", (string)null);
                });

            modelBuilder.Entity("comic.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name");

                    b.HasKey("RoleId")
                        .HasName("PK__role__760965CCFB447E81");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("comic.Models.ShippingMethod", b =>
                {
                    b.Property<int>("ShippingMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shipping_method_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingMethodId"));

                    b.Property<string>("ShippingMethodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("shipping_method_name");

                    b.HasKey("ShippingMethodId")
                        .HasName("PK__shipping__DCF5023B11262AAE");

                    b.ToTable("shipping_methods", (string)null);
                });

            modelBuilder.Entity("comic.Models.StoreOwner", b =>
                {
                    b.Property<int>("StoreOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("store_owner_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreOwnerId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(sysdatetime())");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("(sysdatetime())");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.HasKey("StoreOwnerId")
                        .HasName("PK__store_ow__44C6080230412774");

                    b.ToTable("store_owners", (string)null);
                });

            modelBuilder.Entity("comic.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("tag_name");

                    b.HasKey("TagId")
                        .HasName("PK__tags__4296A2B65A5972CC");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("comic.Models.User", b =>
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

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

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

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

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

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
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
                    b.HasOne("comic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("comic.Models.User", null)
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

                    b.HasOne("comic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("comic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductAuthor", b =>
                {
                    b.HasOne("comic.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Authors_Authors");

                    b.HasOne("comic.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Authors_Products");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("comic.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Tag_Product");

                    b.HasOne("comic.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Tag_Tag");
                });

            modelBuilder.Entity("comic.Models.Cart", b =>
                {
                    b.HasOne("comic.Models.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Products");

                    b.HasOne("comic.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("comic.Models.Image", b =>
                {
                    b.HasOne("comic.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Images_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("comic.Models.Order", b =>
                {
                    b.HasOne("comic.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Order_Statuses");

                    b.HasOne("comic.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Payments");

                    b.HasOne("comic.Models.ShippingMethod", "ShippingMethod")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingMethodId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Shipping_Methods");

                    b.HasOne("comic.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("Payment");

                    b.Navigation("ShippingMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("comic.Models.OrderDetail", b =>
                {
                    b.HasOne("comic.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Details_Orders");

                    b.HasOne("comic.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Details_Products");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("comic.Models.Product", b =>
                {
                    b.HasOne("comic.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Products_Category");

                    b.HasOne("comic.Models.Publisher", "Publisher")
                        .WithMany("Products")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Products_Publisher");

                    b.HasOne("comic.Models.StoreOwner", "StoreOwner")
                        .WithMany("Products")
                        .HasForeignKey("StoreOwnerId")
                        .IsRequired()
                        .HasConstraintName("FK_Products_Store");

                    b.Navigation("Category");

                    b.Navigation("Publisher");

                    b.Navigation("StoreOwner");
                });

            modelBuilder.Entity("comic.Models.User", b =>
                {
                    b.HasOne("comic.Models.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("comic.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("comic.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("comic.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("comic.Models.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("comic.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Images");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("comic.Models.Publisher", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("comic.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("comic.Models.ShippingMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("comic.Models.StoreOwner", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("comic.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
