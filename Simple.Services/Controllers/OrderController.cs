
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Simple.Contracts;

namespace Simple.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        
        await _publishEndpoint.Publish<SubmitOrder>(new SubmitOrder
        {
            OrderId = new Guid(), CustomerNumber = "customerNumber", TimeStamp = DateTime.Now
        });
        return Ok();
    }
}