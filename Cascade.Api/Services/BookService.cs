using Cascade.Api.Data;
using Cascade.Api.Entities;
using Cascade.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade.Api.Services
{
    public interface IBookService
    {
        Task<List<BookModel>> GetOrderedByPublisherAuthorTitle();
        Task<List<BookModel>> GetOrderedByPublisherAuthorTitleFromSp();
        Task<List<BookModel>> GetOrderedByAuthorTitle();
        Task<List<BookModel>> GetOrderedByAuthorTitleFromSp();
        Task<decimal> GetTotalPrice();
        Task InsertBulk(List<Book> books);
    }

    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;

        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<BookModel>> GetOrderedByPublisherAuthorTitle()
        {
            var query = from b in _dataContext.Books
                        orderby b.Publisher, b.AuthorLastName, b.AuthorFirstName, b.Title
                        select b;

            var books = await query.ToListAsync();

            return books.Select(b => MapBookModel(b)).ToList();
        }

        public async Task<List<BookModel>> GetOrderedByPublisherAuthorTitleFromSp()
        {
            var books = await _dataContext.SPGetOrderedByPublisherAuthorTitle();

            return books.Select(b => MapBookModel(b)).ToList();
        }

        public async Task<List<BookModel>> GetOrderedByAuthorTitle()
        {
            var query = from b in _dataContext.Books
                        orderby b.AuthorLastName, b.AuthorFirstName, b.Title
                        select b;

            var books = await query.ToListAsync();

            return books.Select(b => MapBookModel(b)).ToList();
        }

        public async Task<List<BookModel>> GetOrderedByAuthorTitleFromSp()
        {
            var books = await _dataContext.SPGetOrderedByAuthorTitle();

            return books.Select(b => MapBookModel(b)).ToList();
        }

        public async Task<decimal> GetTotalPrice()
        {
            return await _dataContext.Books.SumAsync(x => x.Price);
        }

        private BookModel MapBookModel(Book book)
        {
            return new BookModel
            {
                Publisher = book.Publisher,
                Title = book.Title,
                AuthorLastName = book.AuthorLastName,
                AuthorFirstName = book.AuthorFirstName,
                Price = book.Price,
                CitationMLAStyle = FormatMLAStyle(book.Citation),
                CitationChicagoStyle = FormatChicagoStyle(book.Citation)
            };
        }

        private string FormatMLAStyle(Citation citation)
        {
            return $@"{citation.AuthorLastName}, {citation.AuthorFirstName}. ""{citation.Title}"" <i>{citation.TitleOfContainer}</i>, {citation.Publisher}, {citation.PublicationDate}, {citation.PageNumbers}";
        }

        private string FormatChicagoStyle(Citation citation)
        {
            return $@"{citation.Title}, no. {citation.VolumeNo} ({citation.PublicationDate}): {citation.PageNumbers}. {citation.Url}";
        }

        public async Task InsertBulk(List<Book> books)
        {
            await _dataContext.Books.AddRangeAsync(books);
            await _dataContext.SaveChangesAsync();
        }
    }
}
