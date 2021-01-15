﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryWithCompositeKeys;

namespace RepositoryWithCompositeKeys.Migrations
{
    [DbContext(typeof(CompositeKeyContext))]
    partial class CompositeKeyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("compkey")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RepositoryWithCompositeKeys.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Id = new Guid("00000000-0000-0000-0000-000000000010")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Customer", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupId")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyId", "CustomerId");

                    b.HasIndex("CompanyId", "CustomerGroupId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CustomerId = 2,
                            CustomerGroupId = 3,
                            Id = new Guid("00000000-0000-0000-0000-000000000002")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroup", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupSubGroupAlternateKey")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyId", "CustomerGroupId");

                    b.HasIndex("CustomerGroupSubGroupAlternateKey");

                    b.ToTable("CustomerGroup");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CustomerGroupId = 3,
                            CustomerGroupSubGroupAlternateKey = 1000,
                            Id = new Guid("00000000-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupChild", b =>
                {
                    b.Property<int>("CustomerGroupId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupChildId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupChildNumber")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerGroupCompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerGroupId1")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerGroupId", "CustomerGroupChildId");

                    b.HasIndex("CustomerGroupCompanyId", "CustomerGroupId1");

                    b.ToTable("CustomerGroupChild");

                    b.HasData(
                        new
                        {
                            CustomerGroupId = 3,
                            CustomerGroupChildId = 301,
                            CustomerGroupChildNumber = 1,
                            Description = "Something",
                            Id = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            CustomerGroupId = 3,
                            CustomerGroupChildId = 302,
                            CustomerGroupChildNumber = 2,
                            Description = "SomethingElse",
                            Id = new Guid("00000000-0000-0000-0000-000000000009")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupSubGroup", b =>
                {
                    b.Property<int>("CustomerSubGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerGroupAlternateKey")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerSubGroupId");

                    b.ToTable("CustomerGroupSubGroup");

                    b.HasData(
                        new
                        {
                            CustomerSubGroupId = 100,
                            CustomerGroupAlternateKey = 1000,
                            Id = new Guid("00000000-0000-0000-0000-000000000004")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupSubGroupChild", b =>
                {
                    b.Property<int>("CustomerGroupSubGroupId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupSubGroupChildId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerGroupSubGroupChildNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerGroupSubGroupId", "CustomerGroupSubGroupChildId");

                    b.ToTable("CustomerGroupSubGroupChild");

                    b.HasData(
                        new
                        {
                            CustomerGroupSubGroupId = 100,
                            CustomerGroupSubGroupChildId = 101,
                            CustomerGroupSubGroupChildNumber = 1,
                            Description = "Something",
                            Id = new Guid("00000000-0000-0000-0000-000000000005")
                        },
                        new
                        {
                            CustomerGroupSubGroupId = 100,
                            CustomerGroupSubGroupChildId = 102,
                            CustomerGroupSubGroupChildNumber = 2,
                            Description = "SomethingElse",
                            Id = new Guid("00000000-0000-0000-0000-000000000006")
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerParentCompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("IntOnOtherSideOfDB")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerParentCompanyId", "CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CustomerId = 2,
                            CustomerParentCompanyId = 1,
                            IntOnOtherSideOfDB = 2,
                            OrderId = 1
                        });
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Customer", b =>
                {
                    b.HasOne("RepositoryWithCompositeKeys.Company", "Company")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryWithCompositeKeys.CustomerGroup", "Group")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyId", "CustomerGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroup", b =>
                {
                    b.HasOne("RepositoryWithCompositeKeys.CustomerGroupSubGroup", "SubGroup")
                        .WithMany("CustomerGroups")
                        .HasForeignKey("CustomerGroupSubGroupAlternateKey")
                        .HasPrincipalKey("CustomerGroupAlternateKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubGroup");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupChild", b =>
                {
                    b.HasOne("RepositoryWithCompositeKeys.CustomerGroup", null)
                        .WithMany("Children")
                        .HasForeignKey("CustomerGroupCompanyId", "CustomerGroupId1");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupSubGroupChild", b =>
                {
                    b.HasOne("RepositoryWithCompositeKeys.CustomerGroupSubGroup", null)
                        .WithMany("Children")
                        .HasForeignKey("CustomerGroupSubGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Order", b =>
                {
                    b.HasOne("RepositoryWithCompositeKeys.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerParentCompanyId", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Company", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroup", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("RepositoryWithCompositeKeys.CustomerGroupSubGroup", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("CustomerGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
