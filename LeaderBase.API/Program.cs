using LeaderBase.Business;
using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Core.Common;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<LeaderBaseDbSettings>
    (builder.Configuration.GetSection("LeaderBaseDatabase"));

BusinessDIModule.Inject(builder.Services, builder.Configuration);

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
