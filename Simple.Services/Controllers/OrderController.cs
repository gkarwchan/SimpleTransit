
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Simple.Contracts;

namespace Simple.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    // private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<OrderController> _logger;
    private readonly IRequestClient<SubmitOrder> _client;

    public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> client)
    {
        // _publishEndpoint = publishEndpoint;
        _logger = logger;
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string id, string customerNumber)
    {
        _logger.LogInformation("Received REST CALL for Submit Order");
        /*await _publishEndpoint.Publish<SubmitOrder>(new SubmitOrder
        {
            OrderId = new Guid(id), CustomerNumber = customerNumber, TimeStamp = DateTime.Now
        });*/
        var response = await _client.GetResponse<SubmitOrder, SubmitOrderResponse>(new SubmitOrder
        {
            OrderId = new Guid(id), CustomerNumber = customerNumber
        });
        return Ok(response);
    }
}