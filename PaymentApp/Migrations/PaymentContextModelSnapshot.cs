﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentApp.Data;

#nullable disable

namespace PaymentApp.Migrations
{
    [DbContext(typeof(PaymentContext))]
    partial class PaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaymentApp.Models.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("initial")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("Installment");
                });

            modelBuilder.Entity("PaymentApp.Models.InstallmentTag", b =>
                {
                    b.Property<int>("InstallementId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("InstallementId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("InstallmentTags");
                });

            modelBuilder.Entity("PaymentApp.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("PaymentApp.Models.PaymentInstallment", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("InstallementId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId", "InstallementId");

                    b.HasIndex("InstallementId");

                    b.ToTable("PaymentInstallments");
                });

            modelBuilder.Entity("PaymentApp.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("PaymentApp.Models.Installment", b =>
                {
                    b.HasOne("PaymentApp.Models.Payment", null)
                        .WithMany("installments")
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("PaymentApp.Models.InstallmentTag", b =>
                {
                    b.HasOne("PaymentApp.Models.Installment", "Installment")
                        .WithMany("Tags")
                        .HasForeignKey("InstallementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentApp.Models.Tag", "Tag")
                        .WithMany("InstallmentTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Installment");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PaymentApp.Models.PaymentInstallment", b =>
                {
                    b.HasOne("PaymentApp.Models.Installment", "Installment")
                        .WithMany("PaymentInstallments")
                        .HasForeignKey("InstallementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentApp.Models.Payment", "Payment")
                        .WithMany("PaymentInstallment")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Installment");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("PaymentApp.Models.Installment", b =>
                {
                    b.Navigation("PaymentInstallments");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("PaymentApp.Models.Payment", b =>
                {
                    b.Navigation("PaymentInstallment");

                    b.Navigation("installments");
                });

            modelBuilder.Entity("PaymentApp.Models.Tag", b =>
                {
                    b.Navigation("InstallmentTags");
                });
#pragma warning restore 612, 618
        }
    }
}
