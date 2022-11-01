using Autofac;
using Autofac.Extensions.DependencyInjection;
using LeaderBase.Business;
using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Business.DependecyResolvers.Autofac;
using LeaderBase.Conversion;
using LeaderBase.Core.Common;
using LeaderBase.DataAccess;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<LeaderBaseDbSettings>
    (builder.Configuration.GetSection("LeaderBaseDatabase"));

//BusinessDIModule.Inject(builder.Services, builder.Configuration);

ConversionDIModule.Inject(builder.Services, builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ServiceLocator.InjectServiceProvider(app.Services);



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
