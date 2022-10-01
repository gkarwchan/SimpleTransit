namespace Simple.Contracts;

public interface ISubmitOrderSuccess
{
    Guid OrderId { get; }
    DateTime TimeStamp { get; }
}

public class SubmitOrderSuccess : ISubmitOrderSuccess
{
    public Guid OrderId { get; init; }
    public DateTime TimeStamp { get; init; }
}
