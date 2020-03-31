﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetGreen.Repository.Context;

namespace PetGreen.Repository.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20200331020844_x")]
    partial class x
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetGreen.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CatererID");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("Cep");

                    b.Property<Guid>("CityID");

                    b.Property<string>("Complement")
                        .HasColumnName("Complement");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnName("Neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("Number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("Street");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("CatererID");

                    b.HasIndex("CityID");

                    b.ToTable("CDAddress");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("IBGE")
                        .IsRequired()
                        .HasColumnName("IBGE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<Guid>("StateID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("StateID");

                    b.ToTable("CDCity");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Clinic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("Facebook")
                        .HasColumnName("Facebook");

                    b.Property<string>("Logo")
                        .HasColumnName("Logo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("Site")
                        .HasColumnName("Site");

                    b.Property<string>("SocialReason");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnName("TaxId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("AddressID")
                        .IsUnique();

                    b.ToTable("CDClinic");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CatererID");

                    b.Property<Guid?>("ClinicID");

                    b.Property<string>("ContactType")
                        .HasColumnName("ContactType");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("Number");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CatererID");

                    b.HasIndex("ClinicID");

                    b.HasIndex("UserID");

                    b.ToTable("CDContact");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("ID");

                    b.ToTable("CDProfile");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Register.Breed", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<Guid>("SpecieID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("SpecieID");

                    b.ToTable("CDBreed");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Register.Caterer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClinicID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("Logo")
                        .HasColumnName("Logo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("SocialReason")
                        .IsRequired()
                        .HasColumnName("SocialReason");

                    b.Property<string>("StateRegistration")
                        .HasColumnName("StateRegistration");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnName("TaxId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("ClinicID");

                    b.ToTable("CDCaterer");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Register.Specie", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.ToTable("CDSpecie");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Schedule", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClinicID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Days")
                        .IsRequired()
                        .HasColumnName("Day");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("EndHour")
                        .IsRequired()
                        .HasColumnName("EndHour");

                    b.Property<string>("StartHour")
                        .IsRequired()
                        .HasColumnName("StartHour");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("ClinicID");

                    b.ToTable("CDSchedules");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.State", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnName("UF");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("ID");

                    b.ToTable("CDState");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("ClinicID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PasswordSalt");

                    b.Property<Guid>("ProfileID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("UpdateAt");

                    b.HasKey("ID");

                    b.HasIndex("ClinicID");

                    b.HasIndex("ProfileID");

                    b.ToTable("CDUser");
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Address", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Register.Caterer", "Caterer")
                        .WithMany("Address")
                        .HasForeignKey("CatererID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetGreen.Domain.Entities.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.City", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Clinic", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Address", "Address")
                        .WithOne("Clinic")
                        .HasForeignKey("PetGreen.Domain.Entities.Clinic", "AddressID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Contact", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Register.Caterer", "Caterer")
                        .WithMany("Contacts")
                        .HasForeignKey("CatererID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetGreen.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Contacts")
                        .HasForeignKey("ClinicID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetGreen.Domain.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Register.Breed", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Register.Specie", "Specie")
                        .WithMany("Breeds")
                        .HasForeignKey("SpecieID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Register.Caterer", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Caterers")
                        .HasForeignKey("ClinicID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Schedules")
                        .HasForeignKey("ClinicID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetGreen.Domain.Entities.User", b =>
                {
                    b.HasOne("PetGreen.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Users")
                        .HasForeignKey("ClinicID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PetGreen.Domain.Entities.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
