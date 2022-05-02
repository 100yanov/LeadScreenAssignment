﻿// <auto-generated />
using System;
using LeadScreenAssignment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeadScreenAssignment.Persistence.Migrations
{
    [DbContext(typeof(LeadScreenDbContext))]
    [Migration("20220502115905_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.LeadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubAreaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubAreaId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.PinCodeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PinCodes");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.SubAreaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PinCodeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PinCodeId");

                    b.ToTable("SubAreas");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.LeadEntity", b =>
                {
                    b.HasOne("LeadScreenAssignment.Core.Entities.SubAreaEntity", "SubArea")
                        .WithMany("Leads")
                        .HasForeignKey("SubAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubArea");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.SubAreaEntity", b =>
                {
                    b.HasOne("LeadScreenAssignment.Core.Entities.PinCodeEntity", "PinCode")
                        .WithMany("SubAreas")
                        .HasForeignKey("PinCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PinCode");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.PinCodeEntity", b =>
                {
                    b.Navigation("SubAreas");
                });

            modelBuilder.Entity("LeadScreenAssignment.Core.Entities.SubAreaEntity", b =>
                {
                    b.Navigation("Leads");
                });
#pragma warning restore 612, 618
        }
    }
}
