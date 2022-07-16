﻿// <auto-generated />
using System;
using Cascade.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cascade.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220716161214_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cascade.Api.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Citation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("BookId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("334bfe27-12e9-4131-b891-84b1d29f9f81"),
                            AuthorFirstName = "Marijn",
                            AuthorLastName = "Haverbeke",
                            Citation = "{\"AuthorLastName\":\"Simpson\",\"AuthorFirstName\":\"Kyle\",\"Title\":\"You Don\\u0027t Know JS Yet\",\"TitleOfContainer\":\"You Don\\u0027t Know JS Yet Container\",\"Publisher\":\"No Starch Press\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"103\",\"VolumeNo\":\"2\",\"Url\":\"https://example.com\"}",
                            Price = 47m,
                            Publisher = "No Starch Press",
                            Title = "Eloquent JavaScript, Third Edition"
                        },
                        new
                        {
                            BookId = new Guid("6628fec1-8c1b-4129-81cc-0b239e54a65b"),
                            AuthorFirstName = "Nicolás",
                            AuthorLastName = "Bevacqua",
                            Citation = "{\"AuthorLastName\":\"Chacon\",\"AuthorFirstName\":\"Scott\",\"Title\":\"Pro Git\",\"TitleOfContainer\":\"Pro Git Container\",\"Publisher\":\"O\\u0027Reilly Media\",\"PublicationDate\":\"February 1935\",\"PageNumbers\":\"10-12\",\"VolumeNo\":\"V\",\"Url\":\"https://example.com\"}",
                            Price = 33m,
                            Publisher = "O'Reilly Media",
                            Title = "Practical Modern JavaScript"
                        },
                        new
                        {
                            BookId = new Guid("8a8e5b09-aa66-44f3-a27f-af2ea5ca6b5b"),
                            AuthorFirstName = "Nicholas C.",
                            AuthorLastName = "Zakas",
                            Citation = "{\"AuthorLastName\":\"Sadowski\",\"AuthorFirstName\":\"Caitlin\",\"Title\":\"Rethinking Productivity in Software Engineering\",\"TitleOfContainer\":\"Rethinking Productivity in Software Engineering Contanier\",\"Publisher\":\"Independently published\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"12,14\",\"VolumeNo\":\"III\",\"Url\":\"https://example.com\"}",
                            Price = 35m,
                            Publisher = "Independently published",
                            Title = "Understanding ECMAScript 6"
                        },
                        new
                        {
                            BookId = new Guid("ab37a236-1b48-4fa5-839d-194a5b7c2bcf"),
                            AuthorFirstName = "Axel",
                            AuthorLastName = "Rauschmayer",
                            Citation = "{\"AuthorLastName\":\"Chacon\",\"AuthorFirstName\":\"Scott\",\"Title\":\"Pro Git\",\"TitleOfContainer\":\"Pro Git Container\",\"Publisher\":\"O\\u0027Reilly Media\",\"PublicationDate\":\"February 1935\",\"PageNumbers\":\"10-12\",\"VolumeNo\":\"V\",\"Url\":\"https://example.com\"}",
                            Price = 46m,
                            Publisher = "Apress; 2nd edition",
                            Title = "Speaking JavaScript"
                        },
                        new
                        {
                            BookId = new Guid("35116a3a-9f2a-48da-b08e-81d7d4f81a0d"),
                            AuthorFirstName = "Addy",
                            AuthorLastName = "Osmani",
                            Citation = "{\"AuthorLastName\":\"Sadowski\",\"AuthorFirstName\":\"Caitlin\",\"Title\":\"Rethinking Productivity in Software Engineering\",\"TitleOfContainer\":\"Rethinking Productivity in Software Engineering Contanier\",\"Publisher\":\"Independently published\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"12,14\",\"VolumeNo\":\"III\",\"Url\":\"https://example.com\"}",
                            Price = 25m,
                            Publisher = "Apress",
                            Title = "Learning JavaScript Design Patterns"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
