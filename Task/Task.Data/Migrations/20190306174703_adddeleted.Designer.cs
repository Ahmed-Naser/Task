﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Data;

namespace Task.Data.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20190306174703_adddeleted")]
    partial class adddeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Task.Core.Domain.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNew");

                    b.Property<string>("MimeType");

                    b.Property<string>("SeoFilename");

                    b.Property<string>("TitleAttribute");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Task.Core.Domain.PictureBinary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryData");

                    b.Property<int>("PictureId");

                    b.HasKey("Id");

                    b.HasIndex("PictureId")
                        .IsUnique();

                    b.ToTable("PictureBinary");
                });

            modelBuilder.Entity("Task.Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Task.Core.Domain.ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("PictureId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_Picture_Mapping");
                });

            modelBuilder.Entity("Task.Core.Domain.PictureBinary", b =>
                {
                    b.HasOne("Task.Core.Domain.Picture", "Picture")
                        .WithOne("PictureBinary")
                        .HasForeignKey("Task.Core.Domain.PictureBinary", "PictureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task.Core.Domain.ProductPicture", b =>
                {
                    b.HasOne("Task.Core.Domain.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task.Core.Domain.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
