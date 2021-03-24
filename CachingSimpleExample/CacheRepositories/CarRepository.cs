namespace CachingSimpleExample.CacheRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CachingSimpleExample.CacheRepositories.Abstractions;
    using CachingSimpleExample.Handlers;
    using CachingSimpleExample.Models;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class CarRepository
        : CachingBaseHandler<string, IDictionary<string, Car>>, ICarRepository<string, Car>
    {
        private const string DictionaryCarsKey = "cars";
        private readonly ILogger logger;

        public CarRepository(
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
            : base(memoryCache, loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger(typeof(CarRepository).Name);
        }

        public CrudResult<Car> GetExistingCar(string reference)
        {
            var dictionaryCars = GetAllExistingCar();

            if (dictionaryCars.IsSuccess)
            {
                var car = dictionaryCars.Value
                            .Where(x => x.Key == reference)
                            .SingleOrDefault();

                if (car.Value == null)
                {
                    return CrudResult<Car>.NotFound();
                }
                else
                {
                    return CrudResult<Car>.Success(car.Value);
                }
            }
            else
            {
                return CrudResult<Car>.NotFound();
            }
        }

        public CrudResult InsertOrUpdateExistingCar(Car car)
        {
            var dictionaryCars = GetAllExistingCar();

            if (dictionaryCars.IsSuccess)
            {
                dictionaryCars.Value.Add(car.Reference, car);
                UpdateCacheData(dictionaryCars.Value);
                return CrudResult.Success();
            }
            else
            {
                // Here in other case select to database
                var newDictionary = new Dictionary<string, Car>
                {
                    { car.Reference, car },
                };

                return UpdateCacheData(newDictionary);
            }
        }

        public CrudResult RemoveExistingCar(string reference)
        {
            var dictionaryCars = GetAllExistingCar();

            if (dictionaryCars.IsSuccess)
            {
                var succesfull = dictionaryCars.Value.Remove(reference);
                if (succesfull)
                {
                    return UpdateCacheData(dictionaryCars.Value);
                }
                else
                {
                    return CrudResult.Error();
                }

            }
            else
            {
                return CrudResult.NotFound();
            }
        }

        public CrudResult<IDictionary<string, Car>> GetAllExistingCar()
        {
            var dictionaryCars = GetFromCache(DictionaryCarsKey);

            if (dictionaryCars == null)
            {
                return CrudResult<IDictionary<string, Car>>.NotFound();
            }
            else
            {
                return CrudResult<IDictionary<string, Car>>.Success(dictionaryCars);
            }
        }

        private CrudResult UpdateCacheData(IDictionary<string, Car> carsDictionary)
            => SetOrUpdateInCache(DictionaryCarsKey, carsDictionary) ? CrudResult.Success() : CrudResult.Error();
    }
}