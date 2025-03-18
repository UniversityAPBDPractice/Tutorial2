namespace Tutorial2;

public class OverfillException : Exception
{
    public OverfillException() : base() {}
    public OverfillException(string message) : base(message) {}

    public OverfillException(HazardousContainer c){
        c.Notify();
    }
}