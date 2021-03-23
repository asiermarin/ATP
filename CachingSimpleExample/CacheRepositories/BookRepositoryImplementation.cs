namespace CachingSimpleExample.CacheRepositories
{
    using System;
    using System.Collections.Generic;
    using CachingSimpleExample.CacheRepositories.Abstractions;
    using CachingSimpleExample.Handlers;
    using CachingSimpleExample.Models;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class BookRepositoryImplementation
        : CachingBaseHandler<Key, Book>, IBookRepository
    {
        private readonly ILogger logger;

        public BookRepositoryImplementation(
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
            : base(memoryCache, loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger(typeof(BookRepositoryImplementation).Name);
        }

        public CrudResult<List<Book>> GetAllExistingBook()
        {
            throw new NotImplementedException();
        }

        public CrudResult<Book> GetExistingBook(string id)
        {
            throw new NotImplementedException();
        }

        public CrudResult InsertOrUpdateExistingBook(Book book)
        {
            throw new NotImplementedException();
        }

        public CrudResult RemoveExistingBook(string id)
        {
            throw new NotImplementedException();
        }

        private CrudResult AddBook(Key key, Book book)
            => UpdateInCache(key, book) ? CrudResult.Success() : CrudResult.Error();

        private CrudResult RemoveBook(Key key, Book book)
            => RemoveFromCache(key, book) ? CrudResult.Success() : CrudResult.Error();
    }
}
