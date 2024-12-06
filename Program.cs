using identity_api_asp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var defaultConnection = builder.Configuration["ConnectionString"];
    options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
});

//Identity configuration
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

//Swagger configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();
}

for (var i = 1; i <= 100; ++i) Console.WriteLine($"{i}: VSF BERNARDO");

//Identity configuration
app.MapIdentityApi<IdentityUser>();

//Custom routes
//app.MapGet("/status", () => "OK").RequireAuthorization();

app.Run();