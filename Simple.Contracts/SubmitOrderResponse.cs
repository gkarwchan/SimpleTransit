namespace Simple.Contracts;

public record SubmitOrderResponse
{
    public Guid OrderId { get; init; }
    public string Status { get; init; }
}