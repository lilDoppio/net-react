﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_react.Data;

#nullable disable

namespace net_react.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230411122912_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("net_react.Models.Organizations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Egrip")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Inn")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InnSkan")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OfficeRentSkan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ogrn")
                        .HasMaxLength(13)
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OgrnSkan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ogrnip")
                        .HasMaxLength(15)
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OrgnipSkan")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("RegistartionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("net_react.Models.OrganizationsRequisites", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequisitesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrganizationId", "RequisitesId");

                    b.HasIndex("RequisitesId");

                    b.ToTable("OrganizationsRequisites");
                });

            modelBuilder.Entity("net_react.Models.Requisites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorresponndentAccount")
                        .HasMaxLength(20)
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentAccount")
                        .HasMaxLength(20)
                        .HasColumnType("INTEGER");

                    b.Property<int>("bic")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Requisites");
                });

            modelBuilder.Entity("net_react.Models.OrganizationsRequisites", b =>
                {
                    b.HasOne("net_react.Models.Organizations", "Organizations")
                        .WithMany("OrganizationsRequisites")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_react.Models.Requisites", "Requisites")
                        .WithMany("OrganizationsRequisites")
                        .HasForeignKey("RequisitesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizations");

                    b.Navigation("Requisites");
                });

            modelBuilder.Entity("net_react.Models.Organizations", b =>
                {
                    b.Navigation("OrganizationsRequisites");
                });

            modelBuilder.Entity("net_react.Models.Requisites", b =>
                {
                    b.Navigation("OrganizationsRequisites");
                });
#pragma warning restore 612, 618
        }
    }
}