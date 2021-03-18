namespace Lantek360.Sherlock.Monitoring.Server.Core.Models
{
    public abstract class BaseCrudResult
    {
        public bool IsSuccess => _result == Results.Success;

        public bool IsNotFound => _result == Results.NotFound;

        public bool IsError => _result == Results.Error;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<pendiente>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<pendiente>")]
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
}