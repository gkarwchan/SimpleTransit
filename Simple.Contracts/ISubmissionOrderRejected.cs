namespace Simple.Contracts;

public interface ISubmissionOrderRejected
{
    Guid OrderId { get; }
    string Reason { get; }
}

public class SubmissionOrderRejected : ISubmissionOrderRejected
{
    public Guid OrderId { get; init; }
    public string Reason { get; init; }
}