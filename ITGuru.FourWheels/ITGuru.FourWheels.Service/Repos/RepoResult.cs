namespace ITGuru.FourWheels.Service
{
    public class RepoResult
    {
        public RepoResult(Exception? exception, string? message = null)
        {
            Message = message;
            Exception = exception;
        }
        public string? Message { get; }

        public Exception? Exception { get; }

        public bool Succeeded => Exception != null;
    }
}