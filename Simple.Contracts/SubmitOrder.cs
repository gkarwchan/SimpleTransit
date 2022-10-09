namespace Simple.Contracts
{
    public record SubmitOrder
    {
        public Guid OrderId { get; init; }
        public string CustomerNumber { get; init; }
        public DateTime TimeStamp { get; init; }
    }
}