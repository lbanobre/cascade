using Cascade.Api.Entities;
using Cascade.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cascade.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual Task<List<Book>> SPGetOrderedByPublisherAuthorTitle()
        {
            return Set<Book>().FromSqlInterpolated($"EXEC dbo.spGetOrderedByPublisherAuthorTitle").ToListAsync();
        }

        public virtual Task<List<Book>> SPGetOrderedByAuthorTitle()
        {
            return Set<Book>().FromSqlInterpolated($"EXEC dbo.spGetOrderedByAuthorTitle").ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(Book.OnModelCreating);
            SeedData(modelBuilder);
        }

        internal void SeedData(ModelBuilder modelBuilder)
        {
            var citations = new Citation[] {
                new Citation { Publisher = "No Starch Press", AuthorFirstName = "Kyle", AuthorLastName = "Simpson", Title = "You Don't Know JS Yet", TitleOfContainer = "You Don't Know JS Yet Container", PublicationDate = "2018", PageNumbers = "103", VolumeNo = "2", Url = "https://example.com" },
                new Citation { Publisher = "O'Reilly Media", AuthorFirstName = "Scott", AuthorLastName = "Chacon", Title = "Pro Git", TitleOfContainer = "Pro Git Container", PublicationDate = "February 1935", PageNumbers = "10-12", VolumeNo = "V", Url = "https://example.com" },
                new Citation { Publisher = "Independently published", AuthorFirstName = "Caitlin", AuthorLastName = "Sadowski", Title = "Rethinking Productivity in Software Engineering", TitleOfContainer = "Rethinking Productivity in Software Engineering Contanier", PublicationDate = "2018", PageNumbers = "12,14", VolumeNo = "III", Url = "https://example.com" }
            };

            var books = new Book[] {
                new Book { BookId = Guid.NewGuid(), Publisher = "No Starch Press", AuthorFirstName = "Marijn", AuthorLastName = "Haverbeke", Title = "Eloquent JavaScript, Third Edition", Price = 47, Citation = citations[0] },
                new Book { BookId = Guid.NewGuid(), Publisher = "O'Reilly Media", AuthorFirstName = "Nicolás", AuthorLastName = "Bevacqua", Title = "Practical Modern JavaScript", Price = 33, Citation = citations[1] },
                new Book { BookId = Guid.NewGuid(), Publisher = "Independently published", AuthorFirstName = "Nicholas C.", AuthorLastName = "Zakas", Title = "Understanding ECMAScript 6", Price = 35, Citation = citations[2] },
                new Book { BookId = Guid.NewGuid(), Publisher = "Apress; 2nd edition", AuthorFirstName = "Axel", AuthorLastName = "Rauschmayer", Title = "Speaking JavaScript", Price = 46 , Citation = citations[1]},
                new Book { BookId = Guid.NewGuid(), Publisher = "Apress", AuthorFirstName = "Addy", AuthorLastName = "Osmani" , Title = "Learning JavaScript Design Patterns", Price = 25, Citation = citations[2] }
            };

            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
