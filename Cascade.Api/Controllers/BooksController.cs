using Cascade.Api.Models;
using Cascade.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetOrderedByPublisherAuthorTitle")]
        public async Task<List<BookModel>> GetOrderedByPublisherAuthorTitle()
        {
            return await _bookService.GetOrderedByPublisherAuthorTitle();
        }

        [HttpGet("GetOrderedByPublisherAuthorTitleFromSp")]
        public async Task<List<BookModel>> GetOrderedByPublisherAuthorTitleFromSp()
        {
            return await _bookService.GetOrderedByPublisherAuthorTitleFromSp();
        }

        [HttpGet("GetOrderedByAuthorTitle")]
        public async Task<List<BookModel>> GetOrderedByAuthorTitle()
        {
            return await _bookService.GetOrderedByAuthorTitle();
        }

        [HttpGet("GetOrderedByAuthorTitleFromSp")]
        public async Task<List<BookModel>> GetOrderedByAuthorTitleFromSp()
        {
            return await _bookService.GetOrderedByAuthorTitleFromSp();
        }

        [HttpGet("GetTotalPrice")]
        public async Task<decimal> GetTotalPrice()
        {
            return await _bookService.GetTotalPrice();
        }
    }
}
