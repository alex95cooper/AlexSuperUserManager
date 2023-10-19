using AlexSuperUserManager.DAL;
using AlexSuperUserManager.Scripts;
using Microsoft.EntityFrameworkCore;

Configurator configurator = new();
string connectionString = configurator.GetConnectionString();
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseMySQL(connectionString);
SeedDatabase.Init(optionsBuilder.Options);