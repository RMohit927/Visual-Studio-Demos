using EventHub_Demo.EventHub;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Event Hub Config
var eventHubConfig = configuration.GetSection("EventHub");
builder.Services.AddSingleton(eventHubConfig);
builder.Services.AddSingleton(typeof(IProduceMessages<>), typeof(ProduceMessages<>));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
