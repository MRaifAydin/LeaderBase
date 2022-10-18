using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Core.Common;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<LeaderBaseDbSettings>
    (builder.Configuration.GetSection("LeaderBaseDatabase"));

builder.Services.AddSingleton<IPersonRepository,PersonRepository>();
builder.Services.AddSingleton<ILeaderRepository, LeaderRepository>();
builder.Services.AddSingleton<ILeaderService, LeaderManager>();
builder.Services.AddSingleton<IPersonService, PersonManager>();

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
