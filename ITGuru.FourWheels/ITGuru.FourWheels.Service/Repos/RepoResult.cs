namespace ITGuru.FourWheels.Service
{
    public class RepoResult
    {
        public RepoResult(string message)
        {
            Message = message;
        }
        public string Message { get; }

        public Exception Exception { get; }

        public bool Succeeded => Exception != null;
    }
}