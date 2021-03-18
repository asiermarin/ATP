namespace Lantek360.Sherlock.Monitoring.Server.Core.Models
{
    public class CrudResult<T> : BaseCrudResult
    {
        private CrudResult(Results result)
            : base(result)
        {
        }

        private CrudResult(T value, Results result)
            : this(result)
        {
            Value = value;
        }

        public T Value { get; }

        public static CrudResult<T> Success(T value) => new CrudResult<T>(value, Results.Success);

        public static CrudResult<T> NotFound() => new CrudResult<T>(Results.NotFound);

        public static CrudResult<T> Error() => new CrudResult<T>(Results.Error);
    }
}
