using identity_api_endpoint.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var defaultConnection = builder.Configuration["ConnectionString"];
    options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger();
app.MapIdentityApi<IdentityUser>();

app.MapGet("/status", () => "OK").RequireAuthorization();

app.Run();