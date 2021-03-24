namespace CachingSimpleExample.CacheRepositories.Abstractions
{
    using System.Collections.Generic;
    using CachingSimpleExample.Models;

    public interface ICarRepository<TKey, TValue>
    {
        CrudResult<IDictionary<TKey, TValue>> GetAllExistingCar();

        CrudResult<TValue> GetExistingCar(string reference);

        CrudResult InsertOrUpdateExistingCar(Car car);

        CrudResult RemoveExistingCar(string reference);
    }
}
