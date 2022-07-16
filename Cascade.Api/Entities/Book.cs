using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text.Json;

namespace Cascade.Api.Entities
{
	public class Book
	{
		public Guid BookId { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public Citation Citation { get; set; }


        internal static void OnModelCreating(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Book");
            entity.HasKey(x => x.BookId);
            entity.Property(x => x.Publisher).HasMaxLength(100).IsRequired(); ;
            entity.Property(x => x.Title).HasMaxLength(250).IsRequired();
            entity.Property(x => x.AuthorLastName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.AuthorFirstName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Price).HasColumnType("decimal(10,2)");

            entity.Property(x => x.Citation)
                  .HasConversion(
                      v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                      v => JsonSerializer.Deserialize<Citation>(v, (JsonSerializerOptions)null));
        }
    }
}
