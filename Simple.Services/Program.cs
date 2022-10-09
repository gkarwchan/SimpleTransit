using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((cxt, cfg) =>
    {
        cfg.Host("amqp://localhost:6672", h =>
        {
            h.Username("guest");
            h.Username("guest");
        });
        cfg.ConfigureEndpoints(cxt);
    });
});
builder.Services.AddOptions<MassTransitHostOptions>()
    .Configure(opt =>
    {
        opt.WaitUntilStarted = true;
        opt.StartTimeout = TimeSpan.FromSeconds(10);
        opt.StopTimeout = TimeSpan.FromSeconds(30);
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
