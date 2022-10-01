namespace Simple.Contracts;

public interface ISubmitOrder
{
    Guid OrderId { get;  }
    DateTime TimeStamp { get; }
    string CustomerNumber { get; }
}

public class SubmitOrder : ISubmitOrder
{
    public Guid OrderId { get; init; }
    public DateTime TimeStamp { get; init;  }
    public string CustomerNumber { get; init; }
}