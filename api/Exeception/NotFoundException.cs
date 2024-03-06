namespace api.CustomException
{
    public class NotFoundExecption : Exception
    {
        public NotFoundExecption(string message) : base(message)
        {
        }
    }
}