using AlexSuperUserManager.DAL;
using AlexSuperUserManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexSuperUserManager.Scripts;

public static class SeedDatabase
{
    private static ApplicationDbContext _db;

    public static void Init(DbContextOptions<ApplicationDbContext> options)
    {
        _db = new ApplicationDbContext(options);
        ModelBuilder builder = new ModelBuilder();
        _db.Database.EnsureDeleted();
        _db.Database.EnsureCreated();
        InitTable(builder);
        FillTable();
    }

    private static void InitTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.ToTable("User").HasKey(u => u.NickName);
            builder.Property(u => u.NickName).HasMaxLength(20).IsRequired();
            builder.Property(u => u.FullName).HasMaxLength(25).IsRequired();
        });
    }

    private static void FillTable()
    {
        User[] list = DataFiller.GetUsers();
        _db.User.AddRange(list);
        _db.SaveChanges();
    }
}