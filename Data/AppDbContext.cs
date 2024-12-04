using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace identity_api_endpoint.Data;

public class AppDbContext(DbContextOptions options): IdentityDbContext(options);