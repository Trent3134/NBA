﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NBA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220630012304_Stadium_model_refactor")]
    partial class Stadium_model_refactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlayersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Positions")
                        .HasColumnType("int");

                    b.Property<int?>("TeamEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamEntityId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("StadiumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StadiumCapacity")
                        .HasColumnType("int");

                    b.Property<int>("StadiumLocation")
                        .HasColumnType("int");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("TeamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int?>("StadiumEntityId")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StadiumEntityId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlayersEntity", b =>
                {
                    b.HasOne("TeamEntity", "TeamEntity")
                        .WithMany("Players")
                        .HasForeignKey("TeamEntityId");

                    b.Navigation("TeamEntity");
                });

            modelBuilder.Entity("TeamEntity", b =>
                {
                    b.HasOne("StadiumEntity", null)
                        .WithMany("Teams")
                        .HasForeignKey("StadiumEntityId");
                });

            modelBuilder.Entity("StadiumEntity", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("TeamEntity", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
