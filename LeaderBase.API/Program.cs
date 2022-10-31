using Autofac;
using Autofac.Extensions.DependencyInjection;
using LeaderBase.Business;
using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Business.DependecyResolvers.Autofac;
using LeaderBase.Conversion;
using LeaderBase.Core.Common;
using LeaderBase.Core.Utilities.Security.Encryption;
using LeaderBase.Core.Utilities.Security.JWT;
using LeaderBase.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{ options.AddPolicy(name: "AllowOrigin", configurePolicy: builder => builder.WithOrigins("http://localhost:3000")); });

var tokenOptions = builder.Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.Configure<LeaderBaseDbSettings>
    (builder.Configuration.GetSection("LeaderBaseDatabase"));


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

//BusinessDIModule.Inject(builder.Services, builder.Configuration);

ConversionDIModule.Inject(builder.Services, builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

ServiceLocator.InjectServiceProvider(app.Services);

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();