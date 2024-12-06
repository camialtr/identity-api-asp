using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace identity_api_asp.Data;

public class AppDbContext(DbContextOptions options): IdentityDbContext(options);