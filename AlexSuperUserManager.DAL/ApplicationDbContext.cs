using AlexSuperUserManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexSuperUserManager.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
}