namespace Local.Proyect.Core.Models
{
    public abstract class BaseCrudResult
    {
        public bool IsSuccess => _result == Results.Success;

        public bool IsNotFound => _result == Results.NotFound;

        public bool IsError => _result == Results.Error;

        protected Results _result;

        protected BaseCrudResult(Results result)
        {
            _result = result;
        }

        protected enum Results
        {
            Success,
            NotFound,
            Error
        }
    }

    public class CrudResult : BaseCrudResult
    {
        private CrudResult(Results result)
            : base(result)
        {
        }

        public static CrudResult Success() => new CrudResult(Results.Success);

        public static CrudResult NotFound() => new CrudResult(Results.NotFound);

        public static CrudResult Error() => new CrudResult(Results.Error);

    }

    public class CrudResult<T> : BaseCrudResult
    {
        public T Value { get; }

        private CrudResult(Results result)
            : base(result)
        {
        }

        private CrudResult(T value, Results result)
            : this(result)
        {
            Value = value;
        }

        public static CrudResult<T> Success(T value) => new CrudResult<T>(value, Results.Success);

        public static CrudResult<T> NotFound() => new CrudResult<T>(Results.NotFound);

        public static CrudResult<T> Error() => new CrudResult<T>(Results.Error);
    }
}