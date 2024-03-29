﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20191108101157_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IDataInterface.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookPrice")
                        .HasColumnType("int");

                    b.Property<int>("FindAvailableBooksID")
                        .HasColumnType("int");

                    b.Property<int>("ShelfID")
                        .HasColumnType("int");

                    b.HasKey("BookID");

                    b.HasIndex("ShelfID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("IDataInterface.BookLoan", b =>
                {
                    b.Property<int>("BookLoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("GetBookLoanByBookLoanID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BookLoanID");

                    b.HasIndex("BookID");

                    b.HasIndex("CustomerID");

                    b.ToTable("BookLoans");
                });

            modelBuilder.Entity("IDataInterface.BookShelfAisle", b =>
                {
                    b.Property<int>("BookshelfAisleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookshelfAisleNumber")
                        .HasColumnType("int");

                    b.Property<int>("ShelfID")
                        .HasColumnType("int");

                    b.HasKey("BookshelfAisleID");

                    b.ToTable("BookShelfAisles");
                });

            modelBuilder.Entity("IDataInterface.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookLoansID")
                        .HasColumnType("int");

                    b.Property<string>("CustomersAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomersDateOfBirthYYYYMMDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FindAvailableBooksID")
                        .HasColumnType("int");

                    b.Property<int?>("FindAvailableBooksID1")
                        .HasColumnType("int");

                    b.Property<int>("MoneyDebtID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("FindAvailableBooksID1");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("IDataInterface.FindAvailableBooks", b =>
                {
                    b.Property<int>("FindAvailableBooksID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int?>("BookID1")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustormerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanTimeID")
                        .HasColumnType("int");

                    b.HasKey("FindAvailableBooksID");

                    b.HasIndex("BookID1");

                    b.HasIndex("LoanTimeID");

                    b.ToTable("FindAvailableBooks");
                });

            modelBuilder.Entity("IDataInterface.LoanTime", b =>
                {
                    b.Property<int>("LoanTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FindAvailableBooksID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanTimeID");

                    b.ToTable("LoanTimes");
                });

            modelBuilder.Entity("IDataInterface.MoneyDebt", b =>
                {
                    b.Property<int>("MoneyDebtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("GetActiveMoneyDebt")
                        .HasColumnType("int");

                    b.Property<int>("GetActiveMoneyDebtByCustomer")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MoneyDebtNumber")
                        .HasColumnType("int");

                    b.HasKey("MoneyDebtID");

                    b.HasIndex("CustomerID");

                    b.ToTable("MoneyDebts");
                });

            modelBuilder.Entity("IDataInterface.Shelf", b =>
                {
                    b.Property<int>("ShelfID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookshelfAisleID")
                        .HasColumnType("int");

                    b.Property<int>("BookshelfAisleNumber")
                        .HasColumnType("int");

                    b.Property<int>("GetShelfByShelfNumber")
                        .HasColumnType("int");

                    b.Property<int>("ShelfNumber")
                        .HasColumnType("int");

                    b.HasKey("ShelfID");

                    b.HasIndex("BookshelfAisleID");

                    b.ToTable("Shelfs");
                });

            modelBuilder.Entity("IDataInterface.Book", b =>
                {
                    b.HasOne("IDataInterface.Shelf", "Shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IDataInterface.BookLoan", b =>
                {
                    b.HasOne("IDataInterface.Book", "Book")
                        .WithMany("BookLoan")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDataInterface.Customer", "Customer")
                        .WithMany("BookLoans")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IDataInterface.Customer", b =>
                {
                    b.HasOne("IDataInterface.FindAvailableBooks", "FindAvailableBooks")
                        .WithMany()
                        .HasForeignKey("FindAvailableBooksID1");
                });

            modelBuilder.Entity("IDataInterface.FindAvailableBooks", b =>
                {
                    b.HasOne("IDataInterface.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID1");

                    b.HasOne("IDataInterface.LoanTime", "LoanTime")
                        .WithMany("FindAvailableBookss")
                        .HasForeignKey("LoanTimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IDataInterface.MoneyDebt", b =>
                {
                    b.HasOne("IDataInterface.Customer", "Customer")
                        .WithMany("MoneyDebt")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IDataInterface.Shelf", b =>
                {
                    b.HasOne("IDataInterface.BookShelfAisle", "BookshelfAisle")
                        .WithMany("Shelf")
                        .HasForeignKey("BookshelfAisleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
