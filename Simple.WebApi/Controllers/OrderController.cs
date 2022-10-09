using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Simple.Contracts;

namespace Simple.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IBus _bus;
    private IRequestClient<SubmitOrder> _client;

    public OrderController(ILogger<OrderController> logger, IBus bus, IRequestClient<SubmitOrder> client)
    {
        _logger = logger;
        _bus = bus;
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string id, string customerNumber)
    {
        /*var (accepted, rejected) = await _requestClient.GetResponse<ISubmitOrderSuccess, ISubmissionOrderRejected>(
            new SubmitOrder
            {
                OrderId = Guid.Parse(id), CustomerNumber = customerNumber, TimeStamp = DateTime.Now
            });
        return accepted.IsCompletedSuccessfully ? Accepted((await accepted).Message) :
                BadRequest((await rejected));*/
        
        // await _bus.Publish(new SubmitOrder
        // {
        //     CustomerNumber = "CUS-1", OrderId = new Guid("78C5E48D-019B-4140-837F-7A776B7AAA31"), TimeStamp = DateTime.Now
        // });
        var response = await _client.GetResponse<SubmitOrder, SubmitOrderResponse>(new SubmitOrder
        {
            OrderId = Guid.Parse(id), CustomerNumber = customerNumber, TimeStamp = DateTime.Now
        });
        return Ok(response);
    }
}