namespace Tutorial2;

public class OverfillException : Exception
{
    public OverfillException() : base() {}
    public OverfillException(String message) : base(message) {}
}