namespace api.CustomException
{
    public class UnauthorizedExecption : Exception
    {
        public UnauthorizedExecption(string message) : base(message)
        {
        }
    }
}