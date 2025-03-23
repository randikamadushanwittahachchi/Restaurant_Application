namespace Restaurant.Exceptions
{
    public class DuplicateExeception: Exception
    {
        public DuplicateExeception(string message) : base(message) { }
    }
}
