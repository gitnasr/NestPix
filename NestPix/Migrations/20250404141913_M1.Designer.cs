﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NestPix.Models;

#nullable disable

namespace NestPix.Migrations
{
    [DbContext(typeof(AppDB))]
    [Migration("20250404141913_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("NestPix.Models.Cache", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileSize")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FolderPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("HashID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParentFolder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SessionID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSkipped")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("HashID");

                    b.HasIndex("SessionID");

                    b.ToTable("Caches");
                });

            modelBuilder.Entity("NestPix.Models.Hash", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Hashes");
                });

            modelBuilder.Entity("NestPix.Models.Session", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlreadySeenCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FolderCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastInteraction")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("NestPix.Models.SessionShortcut", b =>
                {
                    b.Property<int>("SessionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShortcutID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionID", "ShortcutID");

                    b.HasIndex("ShortcutID");

                    b.ToTable("SessionShortcuts");
                });

            modelBuilder.Entity("NestPix.Models.Shortcuts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsingCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Shortcuts");
                });

            modelBuilder.Entity("NestPix.Models.Cache", b =>
                {
                    b.HasOne("NestPix.Models.Hash", "Hash")
                        .WithMany()
                        .HasForeignKey("HashID");

                    b.HasOne("NestPix.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hash");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("NestPix.Models.SessionShortcut", b =>
                {
                    b.HasOne("NestPix.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NestPix.Models.Shortcuts", "Shortcut")
                        .WithMany()
                        .HasForeignKey("ShortcutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Shortcut");
                });
#pragma warning restore 612, 618
        }
    }
}
