﻿// <auto-generated />
using Microservices.Coupon.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microservices.Coupon.Api.Migrations
{
    [DbContext(typeof(CouponDbContext))]
    [Migration("20240304122616_InitialCouponDb")]
    partial class InitialCouponDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microservices.Coupon.Api.Data.CouponEntity", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponCode = "1",
                            DiscountAmount = 200.0,
                            MinAmount = 100
                        },
                        new
                        {
                            CouponId = 2,
                            CouponCode = "2",
                            DiscountAmount = 100.0,
                            MinAmount = 50
                        },
                        new
                        {
                            CouponId = 3,
                            CouponCode = "3",
                            DiscountAmount = 50.0,
                            MinAmount = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
