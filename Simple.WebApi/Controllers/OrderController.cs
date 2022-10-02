using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Simple.Contracts;

namespace Simple.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IRequestClient<ISubmitOrder> _requestClient;

    public OrderController(ILogger<OrderController> logger, IRequestClient<ISubmitOrder> requestClient)
    {
        _logger = logger;
        _requestClient = requestClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string id, string customerNumber)
    {
        var (accepted, rejected) = await _requestClient.GetResponse<ISubmitOrderSuccess, ISubmissionOrderRejected>(
            new SubmitOrder
            {
                OrderId = Guid.Parse(id), CustomerNumber = customerNumber, TimeStamp = DateTime.Now
            });
        return accepted.IsCompletedSuccessfully ? Accepted((await accepted).Message) :
                BadRequest((await rejected));
    }
}