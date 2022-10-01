using MassTransit;
using Simple.Consumers;
using Simple.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediator(x =>
{
    x.AddConsumer<SubmitOrderConsumer>();
    x.AddRequestClient<ISubmitOrder>();
});
// Add services to the container.
builder.Services.AddMassTransit(cfg =>
{
   // cfg.AddConsumer<SubmitOrderConsumer>();
   // cfg.AddRequestClient<ISubmitOrder>();
});
builder.Services.AddCors();
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
app.UseCors();
app.MapControllers();

app.Run();