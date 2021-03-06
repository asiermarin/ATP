﻿namespace NCacheExample.CacheRepositories
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using NCacheExample.CacheRepositories.Abstractions;
    using NCacheExample.Handlers;
    using NCacheExample.Models;
    using System.Collections.Generic;

    public class BookRepository : CachingHandler<Book>, IBookRepository
    {
        private readonly ILogger logger;

        public BookRepository(
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
            : base(memoryCache, loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger(typeof(BookRepository).Name);
        }

        public CrudResult<List<Book>> GetAllExistingBook()
        {
            return GetAllBooks();
        }

        public CrudResult InsertOrUpdateExistingBook(Book book)
        {
            var result = GetExistingBook(book.Id);

            if (result.IsSuccess)
            {
                var removeResult = RemoveExistingBook(book);
                if (removeResult.IsSuccess)
                {
                     return AddBook(book);
                }
                else
                {
                    return CrudResult.Error();
                }
            }
            else if (result.IsNotFound)
            {
                return AddBook(book);
            }
            else
            {
                return CrudResult.Error();
            }
        }

        public CrudResult RemoveExistingBook(Book book)
        {
            var result = GetExistingBook(book.Id);

            if (result.IsSuccess)
            {
                return RemoveBook(result.Value);
            }
            else if (result.IsNotFound)
            {
                return CrudResult.NotFound();
            }
            else
            {
                return CrudResult.Error();
            }
        }

        public CrudResult<Book> GetExistingBook(string id)
        {
            var exitingBook = GetFromCache(id, null);

            if (exitingBook != null)
            {
                return CrudResult<Book>.Success(exitingBook);
            }
            else
            {
                return CrudResult<Book>.NotFound();
            }
        }

        private CrudResult<List<Book>> GetAllBooks()
        {
            var booksList = GetAllFromCache();

            if (booksList == null)
            {
                return CrudResult<List<Book>>.Error();
            }
            else
            {
                return CrudResult<List<Book>>.Success(booksList);
            }
        }

        private CrudResult AddBook(Book book)
            => SetInCache(book.Id, book) ? CrudResult.Success() : CrudResult.Error();

        private CrudResult RemoveBook(Book book)
            => RemoveFromCache(book.Id, book) ? CrudResult.Success() : CrudResult.Error();
    }
}
