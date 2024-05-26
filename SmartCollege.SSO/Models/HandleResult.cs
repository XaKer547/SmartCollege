using static MassTransit.ValidationResultExtensions;

namespace SmartCollege.SSO.Models
{
    public record HandleResult 
    {
        public int StatusCode { get; protected init; }
    
        public string Description { get; protected init; }

        protected HandleResult(int statusCode, string desctiption)
        {
            StatusCode = statusCode;
            Description = desctiption;
        }

        public static HandleResult Success(int statusCode, string description)
        {
            return new HandleResult(statusCode, description);
        }

        public static HandleResult Failure(int statusCode, string description)
        {
            return new HandleResult(statusCode, description);
        }
    }

    public record HandleResult<T> : HandleResult
    {
        public T? Result { get; }

        private HandleResult(
            int statusCode, 
            string desctiption,
            T result) : base(statusCode, desctiption)
        {
            StatusCode = statusCode;
            Description = desctiption;
            Result = result;
        }

        private HandleResult(
            int statusCode,
            string desctiption) : base(statusCode, desctiption)
        {
        }

        public static HandleResult<T> Success(int statusCode, string description, T result)
        {
            return new HandleResult<T>(statusCode, description, result);
        }

        public static new HandleResult<T> Failure(int statusCode, string description)
        {
            return new HandleResult<T>(statusCode, description);
        }
    }
}
