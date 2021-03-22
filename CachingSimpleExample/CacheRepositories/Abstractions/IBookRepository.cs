namespace CachingSimpleExample.CacheRepositories.Abstractions
{
    using CachingSimpleExample.Models;
    using System.Collections.Generic;

    public interface IBookRepository
    {
        CrudResult<List<Book>> GetAllExistingBook();

        CrudResult<Book> GetExistingBook(string id);

        CrudResult InsertOrUpdateExistingBook(Book book);

        CrudResult RemoveExistingBook(Book book);
    }
}