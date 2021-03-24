namespace CachingSimpleExample.CacheRepositories.Abstractions
{
    using CachingSimpleExample.Models;
    using System.Collections.Generic;

    public interface IBookRepository<T>
    {
        CrudResult<List<T>> GetAllExistingBook();

        CrudResult<T> GetExistingBook(string id);

        CrudResult InsertOrUpdateExistingBook(Book book);

        CrudResult RemoveExistingBook(string id);
    }
}