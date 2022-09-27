namespace ITGuru.FourWheels.Service
{
    public class RepoResult
    {
        public RepoResult(string message)
        {
            Message = message;
        }
        public string Message { get; set; }

        public Exception Exception { get; set; } = null;

        public bool Succeeded => Exception != null;
    }
}