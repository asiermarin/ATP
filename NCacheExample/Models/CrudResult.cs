namespace NCacheExample.Models
{
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
}