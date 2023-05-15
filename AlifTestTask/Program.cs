using AlifTestTask.Services.CardActivityNotifier;
using AlifTestTask.Services.CardActivityStorage;
using AlifTestTask.Services.CardWorkerNotifier;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<CardWorkerNotifier>();
builder.Services.AddSingleton<ICardStorage, InMemoryCardStorage>();
builder.Services.AddSingleton<ICardNotifier, ConsoleCardNotifier>();

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
